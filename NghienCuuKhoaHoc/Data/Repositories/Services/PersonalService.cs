using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Extension;
using NghienCuuKhoaHoc.Models;
using System.Linq;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class PersonalService : IPersonalService
    {
        private readonly Context context;
        public PersonalService(Context _context)
        {
            context = _context;
        }
        public async Task<bool> AddAsync(PersonalViewModel personal)
        {
            try
            {

                if (context.Personals.Where(d => d.Id == personal.Id).ToList().Count() > 0)
                {
                    return false;
                }

                var personalNew = new Personal()
                {
                    Id = personal.Id,
                    Name = personal.Name,
                    Position = personal.Position,
                    PhoneNumber = personal.PhoneNumber,
                    Literacy = personal.Literacy,
                    Email = personal.Email,
                    DepartmentId = personal.DepartmentId,
                    Avatar = personal.Avatar,
                    Gender = personal.Gender=="Nam"?true:false,
                };

                if(personal.Birth != null &&personal.Birth != "")
                {
                    personalNew.Birth = personal.Birth.ToDateTime();
                }
                if(personal.NewAvatar != null && personal.NewAvatar.Length > 0)
                {
                    personalNew.Avatar = await personal.NewAvatar.SavePersonalImageAsync();
                }
                

                context.Add(personalNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    if (personalNew.Literacy != null && personalNew.Literacy != "")
                    {
                        List<string> Literacies = context.Literacies.Select(e => e.Value).ToList();
                        if (!Literacies.Contains(personalNew.Literacy))
                        {
                            context.Add(new Literacy() { Value = personalNew.Literacy });
                        }
                    }
                    if (personalNew.Position != null && personalNew.Position != "")
                    {
                        List<string> Positions = context.Positions.Select(e => e.Value).ToList();
                        if (!Positions.Contains(personalNew.Position))
                        {
                            context.Add(new Position() { Value = personalNew.Position });
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch {return false;}
        }

        public async Task<bool> DeleteRange(List<string> personals)
        {
            try
            {
                List<Personal> _personals = context.Personals.Where(e => personals.Contains(e.Id)).ToList();
                foreach (var _personal in _personals)
                {
                    if (_personal.Avatar != null && _personal.Avatar != "")
                    {
                        System.IO.File.Delete(Path.Combine(@"wwwroot", _personal.Avatar.Substring(1)));
                    }
                }
                List<CouncilMember> members = context.CouncilMembers.Where(e => personals.Contains(e.MemberId)).ToList();
                context.RemoveRange(members);
                context.RemoveRange(_personals);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<IPagedList<PersonalViewModel>> GetPersonals(int page = 1, int pageSize = 1, string? Department = null, string? FindKeyword = null)
        {
            List<PersonalViewModel> res = context.Personals
                .Include(e => e.Department)
                .OrderBy(e => e.Name)
                .Select(e =>
                    new PersonalViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Avatar = e.Avatar == "" || e.Avatar == null ? "/plugins/images/users/1.jpg" : e.Avatar,
                        Birth = e.Birth.ToDate(),
                        DepartmentId = e.DepartmentId,
                        Email = e.Email,
                        Literacy = e.Literacy,
                        PhoneNumber = e.PhoneNumber,
                        Position = e.Position,
                        Department = e.Department.Name,
                        Gender = e.Gender == null ? null : e.Gender == true ? "Nam" : "Nữ"
                    })
                .ToList();
            if (Department!=null)
            {
                res = res.Where(e=>e.DepartmentId == Department).ToList(); 
            }
            if (FindKeyword != null)
            {
                res = res.Where(e => e.Id.Contains(FindKeyword) 
                || e.Name.Contains(FindKeyword) 
                || e.DepartmentId.Contains(FindKeyword) 
                || e.Department.Contains(FindKeyword)
                || e.Literacy.Contains(FindKeyword)
                || e.PhoneNumber.Contains(FindKeyword)
                || e.Position.Contains(FindKeyword)
                || e.Email.Contains(FindKeyword)).ToList();
            }
            return res.ToPagedList(page, pageSize);
        }

        public async Task<PersonalDetailViewModel> PersonalDetail(string id)
        {
            return context.Personals
                .Include(e => e.Researches)
                .Include(e => e.Department)
                .Where(e => e.Id == id)
                .Select(e => new PersonalDetailViewModel
                {
                    Id = e.Id,
                    Avatar = e.Avatar,
                    Birth = e.Birth.Value.ToString("dd-MM-yyyy"),
                    Department = e.Department.Name,
                    Name = e.Name,
                    Email = e.Email,
                    Gender = e.Gender == null ? null : e.Gender == true ? "Nam" : "Nữ",
                    Literacy = e.Literacy,
                    PhoneNumber = e.PhoneNumber,
                    Position = e.Position,
                    Researches = e.Researches.Select(e => new ResearchDetailViewModel() { Id = e.Id, Subject = e.Subject, Field = e.Field, Status = e.Status }).ToList(),

                }).FirstOrDefault();
        }

        public async Task<int> TotalPersonal()
        {
            return context.Personals.Count();
        }

        public async Task<bool> UpdateAsync(PersonalViewModel personal)
        {
            try
            {
                var personalNew = context.Personals.Where(e=>e.Id == personal.Id).FirstOrDefault();
                if (personalNew == null) { return false; }

                personalNew.Name = personal.Name;
                personalNew.DepartmentId = personal.DepartmentId;
                personalNew.Email = personal.Email;
                personalNew.Literacy = personal.Literacy;
                personalNew.PhoneNumber = personal.PhoneNumber;
                personalNew.Position = personal.Position;
                personalNew.Gender = personal.Gender == "Nam" ? true : false;
                if (personal.Birth != null && personal.Birth != "")
                {
                    var birth = personal.Birth.Split("-");
                    personalNew.Birth = new DateTime(int.Parse(birth[0]), int.Parse(birth[1]), int.Parse(birth[2]), 0, 0, 0);
                }
                if (personal.NewAvatar != null && personal.NewAvatar.Length > 0)
                {
                    if (personalNew.Avatar != null && personalNew.Avatar != "")
                    {
                        System.IO.File.Delete(Path.Combine(@"wwwroot", personalNew.Avatar.Substring(1)));
                    }
                    personalNew.Avatar = await personal.NewAvatar.SavePersonalImageAsync();
                }
                
                context.Update(personalNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    if (personalNew.Literacy != null && personalNew.Literacy != "")
                    {
                        List<string> Literacies = context.Literacies.Select(e => e.Value).ToList();
                        if (!Literacies.Contains(personalNew.Literacy))
                        {
                            context.Add(new Literacy() { Value = personalNew.Literacy });
                        }
                    }
                    if (personalNew.Position != null && personalNew.Position != "")
                    {
                        List<string> Positions = context.Positions.Select(e => e.Value).ToList();
                        if (!Positions.Contains(personalNew.Position))
                        {
                            context.Add(new Position() { Value = personalNew.Position });
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

    }
}
