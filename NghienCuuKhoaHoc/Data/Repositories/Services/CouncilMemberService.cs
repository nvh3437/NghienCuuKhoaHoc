using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.General.Extension;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class CouncilMemberService : ICouncilMemberService
    {
        private readonly Context context;
        public CouncilMemberService(Context _context)
        {
            context = _context;
        }
        public async Task<bool> UpdateRange(CouncilMemberViewModel model)
        {
            try
            {
                var Res = context.Researches
                    .Include(e=>e.CouncilMembers)
                    .Where(e => model.selectedResearches.Contains(e.Id)).ToList();
                foreach (var Re in Res)
                {
                    context.RemoveRange(Re.CouncilMembers);
                    if (model.Chairman != null && model.Chairman != "")
                    {
                        await context.AddAsync(new CouncilMember()
                        {
                            ResearchId = Re.Id,
                            MemberId = model.Chairman,
                            Position = General.Enum.PositionCouncil.Chairman
                        });

                    }
                    if (model.Commissioner1 != null && model.Commissioner1 != "")
                    {
                        await context.AddAsync(new CouncilMember()
                        {
                            ResearchId = Re.Id,
                            MemberId = model.Commissioner1,
                            Position = General.Enum.PositionCouncil.Commissioner1
                        });
                    }
                    if (model.Commissioner2 != null && model.Commissioner2 != "")
                    {
                        await context.AddAsync(new CouncilMember()
                        {
                            ResearchId = Re.Id,
                            MemberId = model.Commissioner2,
                            Position = General.Enum.PositionCouncil.Commissioner2
                        });
                    }
                    if (model.Secretary != null && model.Secretary != "")
                    {
                        await context.AddAsync(new CouncilMember()
                        {
                            ResearchId = Re.Id,
                            MemberId = model.Secretary,
                            Position = General.Enum.PositionCouncil.Secretary
                        });
                    }
                }
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch {return false;}
        }

        public async Task<bool> DeleteRange(CouncilMemberViewModel model)
        {
            try
            {
                var Res = context.Researches
                    .Include(e => e.CouncilMembers)
                    .Where(e => model.selectedResearches.Contains(e.Id)).ToList();
                foreach (var Re in Res)
                {
                    context.RemoveRange(Re.CouncilMembers);
                }
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<IPagedList<CouncilMemberViewModel>> GetMembers(int page = 1, int pageSize = 1, string? Field = null, ResearchStatus? Status = null, int? Year = null, string? FindKeyword = null)
        {
            var res = context.Researches
                .Include(e => e.Personal)
                .Include(e => e.CouncilMembers).ThenInclude(e => e.Personal)
                .OrderByDescending(e=>e.DateStarted)
                .Select(e => new CouncilMemberViewModel
                {
                    ResearchId = e.Id,
                    DateStarted = e.DateStarted.ToDate(),
                    DateExpired = e.DateExpired.ToDate(),
                    Field = e.Field,
                    Status = e.Status,
                    Instructor = e.Personal.Name,
                    Subject = e.Subject,
                    Members = e.CouncilMembers,
                    Chairman = e.CouncilMembers.Where(e=>e.Position == General.Enum.PositionCouncil.Chairman)
                        .Select(e=>e.MemberId).FirstOrDefault(),
                    Commissioner1 = e.CouncilMembers.Where(e=>e.Position == General.Enum.PositionCouncil.Commissioner1)
                        .Select(e=>e.MemberId).FirstOrDefault(),
                    Commissioner2 = e.CouncilMembers.Where(e=>e.Position == General.Enum.PositionCouncil.Commissioner2)
                        .Select(e=>e.MemberId).FirstOrDefault(),
                    Secretary = e.CouncilMembers.Where(e=>e.Position == General.Enum.PositionCouncil.Secretary)
                        .Select(e=>e.MemberId).FirstOrDefault(),
                    Year = e.DateStarted.Value.Year
                })
                .ToList();
            if (Field != null)
            {
                res = res.Where(e => e.Field == Field).ToList();
            }
            if (Status != null)
            {
                res = res.Where(e => e.Status == Status).ToList();
            }
            if (Year != null)
            {
                res = res.Where(e => e.Year == Year).ToList();
            }
            if (FindKeyword != null)
            {
                res = res.Where(e => e.Field.Contains(FindKeyword) 
                || e.ResearchId.Contains(FindKeyword) 
                || e.Instructor.Contains(FindKeyword) 
                || e.Subject.Contains(FindKeyword) 
                || e.Chairman.Contains(FindKeyword)
                || e.Commissioner1.Contains(FindKeyword)
                || e.Commissioner2.Contains(FindKeyword)
                || e.Secretary.Contains(FindKeyword)).ToList();
            }
            return res.ToPagedList(page, pageSize);
        }

        public async Task<bool> UpdateAsync(CouncilMemberViewModel model)
        {
            try
            {
                var Re = context.Researches
                    .Include(e => e.CouncilMembers)
                    .Where(e => model.ResearchId == e.Id).FirstOrDefault();
                context.RemoveRange(Re.CouncilMembers);
                if (model.Chairman != null && model.Chairman != "")
                {
                    await context.AddAsync(new CouncilMember()
                    {
                        ResearchId = Re.Id,
                        MemberId = model.Chairman,
                        Position = General.Enum.PositionCouncil.Chairman
                    });

                }
                if (model.Commissioner1 != null && model.Commissioner1 != "")
                {
                    await context.AddAsync(new CouncilMember()
                    {
                        ResearchId = Re.Id,
                        MemberId = model.Commissioner1,
                        Position = General.Enum.PositionCouncil.Commissioner1
                    });
                }
                if (model.Commissioner2 != null && model.Commissioner2 != "")
                {
                    await context.AddAsync(new CouncilMember()
                    {
                        ResearchId = Re.Id,
                        MemberId = model.Commissioner2,
                        Position = General.Enum.PositionCouncil.Commissioner2
                    });
                }
                if (model.Secretary != null && model.Secretary != "")
                {
                    await context.AddAsync(new CouncilMember()
                    {
                        ResearchId = Re.Id,
                        MemberId = model.Secretary,
                        Position = General.Enum.PositionCouncil.Secretary
                    });
                }
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

    }
}
