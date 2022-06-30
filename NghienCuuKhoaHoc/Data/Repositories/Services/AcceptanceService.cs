using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.General.Extension;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class AcceptanceService : IAcceptanceService
    {
        private readonly Context context;
        public AcceptanceService(Context _context)
        {
            context = _context;
        }
        public async Task<bool> DeleteRange(AcceptanceViewModel model)
        {
            try
            {
                var Res = context.Researches
                    .Include(e => e.ResearchAcceptance)
                    .Where(e => model.selectedResearches.Contains(e.Id)).ToList();
                foreach (var Re in Res)
                {
                    if (Re.ResearchAcceptance != null)
                        context.Remove(Re.ResearchAcceptance);
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

        public async Task<IPagedList<AcceptanceViewModel>> GetAcceptances(int page = 1, int pageSize = 1, string? Field = null, General.Enum.AcceptanceStatus? Acceptance = null, General.Enum.AcceptanceRate? Rate = null, int? Year = null, string? FindKeyword = null)
        {
            var res = context.Researches
                .Include(e => e.Personal)
                .Include(e => e.ResearchAcceptance)
                .OrderByDescending(e => e.DateStarted)
                .Select(e => new AcceptanceViewModel
                {
                    ResearchId = e.Id,
                    DateStarted = e.DateStarted.ToDate(),
                    DateExpired = e.DateExpired.ToDate(),
                    Field = e.Field,
                    Acceptance = e.ResearchAcceptance.Acceptance,
                    Instructor = e.Personal.Name,
                    Subject = e.Subject,
                    Rate = e.ResearchAcceptance.Rating,
                    Score = e.ResearchAcceptance.Score.Value,
                    Year = e.DateStarted.Value.Year
                })
                .ToList();
            if (Field != null)
            {
                res = res.Where(e => e.Field == Field).ToList();
            }
            if (Acceptance != null)
            {
                res = res.Where(e => e.Acceptance == Acceptance).ToList();
            }
            if (Rate != null)
            {
                res = res.Where(e => e.Rate == Rate).ToList();
            }
            if (Year != null)
            {
                res = res.Where(e => e.Year == Year).ToList();
            }
            if(FindKeyword != null)
            {
                res = res.Where(e => e.Field.Contains(FindKeyword) 
                || e.ResearchId.Contains(FindKeyword) 
                || e.Instructor.Contains(FindKeyword) 
                || e.Subject.Contains(FindKeyword)).ToList();
            }
            return res.ToPagedList(page,pageSize);
        }

        public async Task<bool> UpdateAsync(AcceptanceViewModel model)
        {
            try
            {
                var Re = context.Researches
                    .Include(e => e.ResearchAcceptance)
                    .Where(e => model.ResearchId == e.Id).FirstOrDefault();
                if(Re.ResearchAcceptance != null)
                    context.Remove(Re.ResearchAcceptance);
                if (model.Score != null)
                {
                    var Acceptance = new ResearchAcceptance()
                    {
                        ResearchId = model.ResearchId,
                        Score = model.Score.Value,
                        Acceptance = model.Score.ToAcceptanceStatus(),
                        Rating = model.Score.ToAcceptanceRate()
                    };
                    context.Add(Acceptance);
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
        public async Task<int> TotalAcceptedResearch()
        {
            return context.ResearchAcceptances.Where(e => e.Acceptance == General.Enum.AcceptanceStatus.Pass).Count();
        }


    }
}
