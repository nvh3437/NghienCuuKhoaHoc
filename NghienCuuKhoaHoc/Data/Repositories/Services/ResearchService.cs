using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.General.Extension;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class ResearchService : IResearchService
    {
        private readonly Context context;
        public ResearchService(Context _context)
        {
            context = _context;
        }
        public async Task<bool> AddAsync(ResearchViewModel re)
        {
            try
            {
                if (context.Researches.Where(d => d.Id == re.Id).ToList().Count() > 0)
                {
                    return false;
                }

                var reNew = new Research()
                {
                    Id = re.Id,
                    Subject = re.Subject,
                    DateExpired = re.DateExpired.ToDateTime(),
                    DateStarted = re.DateStarted.ToDateTime(),
                    Expense = re.Expense.GetValueOrDefault(),
                    Field = re.Field,
                    InstructorId = re.InstructorId,
                    Status = re.Status,
                };

               
                context.Add(reNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    if (re.NewResearchFiles != null && re.NewResearchFiles.Count > 0)
                    {
                        List<ResearchFile> ResearchFiles = new List<ResearchFile>();
                        foreach (var item in re.NewResearchFiles)
                        {
                            
                            ResearchFile file = await item.SaveResearchFileAsync(reNew.Id);
                            ResearchFiles.Add(new ResearchFile()
                            {
                                Id = file.Id,
                                File = file.File,
                                FileExtend = file.FileExtend,
                                Name = file.Name,
                                ResearchId = file.ResearchId,
                                Research = reNew,
                            });
                            
                        }
                        await context.AddRangeAsync(ResearchFiles);
                    }
                    if (reNew.Field != null && reNew.Field != "")
                    {
                        List<string> Fields = context.Fields.Select(e => e.Value).ToList();
                        if (!Fields.Contains(reNew.Field))
                        {
                            context.Add(new Field() { Value = reNew.Field });
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch {return false;}
        }

        public async Task<bool> DeleteRange(List<string> Researches)
        {
            try
            {
                List<Research> _Researches = context.Researches.Where(e => Researches.Contains(e.Id)).ToList();
                List<ResearchFile> DeleteFiles = context.ResearchFiles.Where(e => Researches.Contains(e.ResearchId)).ToList();
                List<CouncilMember> members = context.CouncilMembers.Where(e => Researches.Contains(e.ResearchId)).ToList();
                context.RemoveRange(members);
                context.RemoveRange(_Researches);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    foreach (var item in DeleteFiles)
                    {
                        System.IO.File.Delete(Path.Combine(@"wwwroot", item.File.Substring(1)));
                    }
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        
        public async Task<bool> ExtendRange(List<string> Researches, int years = 0, int months = 0, int days = 0)
        {
            try
            {
                List<Research> _Researches = context.Researches.Where(e => Researches.Contains(e.Id)).ToList();
                foreach (var item in _Researches)
                {
                    if(item.Status < ResearchStatus.Inspected)
                    {
                        item.DateExpired = item.DateExpired.Value.AddYears(years);
                        item.DateExpired = item.DateExpired.Value.AddMonths(months);
                        item.DateExpired = item.DateExpired.Value.AddDays(days);
                    }
                }
                context.UpdateRange(_Researches);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<IPagedList<ResearchViewModel>> GetResearches(int page = 1, int pageSize = 1, string? Field = null, ResearchStatus? Status = null, int? Year = null, string? FindKeyword = null)
        {
            var res = context.Researches
                .Include(e=>e.Personal)
                .Include(e=>e.ResearchFiles)
                .OrderByDescending(e => e.DateStarted)
                .Select(e=>new ResearchViewModel
                {
                    Id = e.Id,
                    DateExpired = e.DateExpired.ToDate(),
                    DateStarted = e.DateStarted.ToDate(),
                    Expense = e.Expense,
                    Field = e.Field,
                    Instructor = e.Personal.Name,
                    InstructorId = e.InstructorId,
                    Status = e.Status,
                    Subject = e.Subject,
                    ResearchFiles = e.ResearchFiles,
                    Year = e.DateStarted.Value.Year
                })
                .ToList();
            if (FindKeyword != null)
            {
                res = res.Where(e => e.Id.Contains(FindKeyword) 
                || e.Field.Contains(FindKeyword) 
                || e.Instructor.Contains(FindKeyword) 
                || e.InstructorId.Contains(FindKeyword) 
                || e.Subject.Contains(FindKeyword)).ToList();
            }
            if (Field != null)
            {
                res = res.Where(e=>e.Field == Field).ToList();
            }
            if(Status != null)
            {
                res = res.Where(e=>e.Status == Status).ToList();
            }
            if (Year != null)
            {
                res = res.Where(e => e.Year == Year).ToList();
            }
            return res.ToPagedList(page, pageSize);
        }

        public async Task<List<ResearchViewModel>> RecentResearches()
        {
            var res = context.Researches
                .Include(e => e.Personal)
                .Include(e => e.ResearchFiles)
                .OrderByDescending(e => e.DateStarted)
                .Take(10)
                .Select(e => new ResearchViewModel
                {
                    Id = e.Id,
                    DateExpired = e.DateExpired.ToDate(),
                    DateStarted = e.DateStarted.ToDate(),
                    Expense = e.Expense,
                    Field = e.Field,
                    Instructor = e.Personal.Name,
                    InstructorId = e.InstructorId,
                    Status = e.Status,
                    Subject = e.Subject,
                    ResearchFiles = e.ResearchFiles
                })
                .ToList();
            return res;
        }

        public async Task<ResearchDetailViewModel> ResearchDetail(string id)
        {
            return context.Researches
                .Include(e => e.Personal)
                .Include(e => e.ResearchFiles)
                .Include(e => e.CouncilMembers).ThenInclude(e=>e.Personal)
                .Include(e => e.ResearchAcceptance)
                .Where(e=>e.Id == id)
                .Select(e => new ResearchDetailViewModel
                {
                    Id = e.Id,
                    DateExpired = e.DateExpired.Value.ToString("dd-MM-yyyy"),
                    DateStarted = e.DateStarted.Value.ToString("dd-MM-yyyy"),
                    Expense = e.Expense,
                    Field = e.Field,
                    Instructor = e.Personal.Name,
                    InstructorId = e.InstructorId,
                    Status = e.Status,
                    Subject = e.Subject,
                    ResearchFiles = e.ResearchFiles,
                    Chairman = e.CouncilMembers.Where(e => e.Position == General.Enum.PositionCouncil.Chairman)
                        .Select(e => e.Personal.Name).FirstOrDefault(),
                    Commissioner1 = e.CouncilMembers.Where(e => e.Position == General.Enum.PositionCouncil.Commissioner1)
                        .Select(e => e.Personal.Name).FirstOrDefault(),
                    Commissioner2 = e.CouncilMembers.Where(e => e.Position == General.Enum.PositionCouncil.Commissioner2)
                        .Select(e => e.Personal.Name).FirstOrDefault(),
                    Secretary = e.CouncilMembers.Where(e => e.Position == General.Enum.PositionCouncil.Secretary)
                        .Select(e => e.Personal.Name).FirstOrDefault(),
                    Acceptance = e.ResearchAcceptance.Acceptance,
                    Rate = e.ResearchAcceptance.Rating,
                    Score = e.ResearchAcceptance.Score.Value,
                }).FirstOrDefault();
        }

        public async Task<int> TotalResearch()
        {
            return context.Researches.Count();
        }

        public async Task<bool> UpdateAsync(ResearchViewModel re)
        {
            try
            {
                var reNew = context.Researches.Where(e => e.Id == re.Id).FirstOrDefault();
                if (reNew == null) { return false; }

                reNew.Subject = re.Subject;
                reNew.DateExpired = re.DateExpired.ToDateTime();
                reNew.DateStarted = re.DateStarted.ToDateTime();
                reNew.Expense = re.Expense.GetValueOrDefault();
                reNew.Field = re.Field;
                reNew.InstructorId = re.InstructorId;
                reNew.Status = re.Status;

                
                context.Update(reNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    if (re.DeleteFiles != null && re.DeleteFiles.Count > 0)
                    {
                        var DeleteFiles = context.ResearchFiles.Where(e => re.DeleteFiles.Contains(e.Id)).ToList();
                        foreach (var item in DeleteFiles)
                        {
                            System.IO.File.Delete(Path.Combine(@"wwwroot", item.File.Substring(1)));
                            
                        }
                        context.RemoveRange(DeleteFiles);
                    }
                    if (re.NewResearchFiles != null && re.NewResearchFiles.Count > 0)
                    {
                        List<ResearchFile> ResearchFiles = new List<ResearchFile>();
                        foreach (var item in re.NewResearchFiles)
                        {
                            
                            ResearchFile file = await item.SaveResearchFileAsync(reNew.Id);
                            ResearchFiles.Add(new ResearchFile()
                            {
                                Id = file.Id,
                                File = file.File,
                                FileExtend = file.FileExtend,
                                Name = file.Name,
                                ResearchId = file.ResearchId,
                                Research = reNew,
                            });
                            
                        }
                        await context.AddRangeAsync(ResearchFiles);
                    }
                    if (re.Field != null && re.Field != "")
                    {
                        List<string> Fields = context.Fields.Select(e => e.Value).ToList();
                        if (!Fields.Contains(re.Field))
                        {
                            context.Add(new Field() { Value = re.Field });
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<List<int>> Years()
        {
            return context.Researches.Select(e=>e.DateStarted.Value.Year).Distinct().ToList();
        }
    }
}
