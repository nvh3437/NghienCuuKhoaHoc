using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var User1 = new IdentityUser()
            {
                Id = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE").ToString(),
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "Ngohung3437@gmail.com",
                NormalizedEmail = "Ngohung3437@gmail.com",
                EmailConfirmed = false,
                SecurityStamp = string.Empty,
            };
            User1.PasswordHash = hasher.HashPassword(User1, "admin");

            var User2 = new IdentityUser()
            {
                Id = new Guid("72BD714F-4856-45BA-B5B7-F00649BE00DE").ToString(),
                UserName = "admin1",
                NormalizedUserName = "admin1",
                Email = "Ngohung3437@gmail.com",
                NormalizedEmail = "Ngohung3437@gmail.com",
                EmailConfirmed = false,
                SecurityStamp = string.Empty,
            };
            User2.PasswordHash = hasher.HashPassword(User2, "admin");
            
            var User3 = new IdentityUser()
            {
                Id = new Guid("72BD714F-7812-45BA-B5B7-F00649BE00DE").ToString(),
                UserName = "admin2",
                NormalizedUserName = "admin2",
                Email = "Ngohung3437@gmail.com",
                NormalizedEmail = "Ngohung3437@gmail.com",
                EmailConfirmed = false,
                SecurityStamp = string.Empty,
            };
            User3.PasswordHash = hasher.HashPassword(User3, "admin");

            builder.Entity<IdentityUser>().HasData(User1,User2,User3);

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = new Guid("CAEA4300-91D6-42F8-9DD7-80F8C9F6F88F").ToString(),
                Name = "Admin",
                NormalizedName = "Admin"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = new Guid("CAEA4300-91D6-42F8-9DD7-80F8C9F6F88F").ToString(),
                    UserId = new Guid("72BD714F-7812-45BA-B5B7-F00649BE00DE").ToString(),
                }, 
                new IdentityUserRole<string>
                {
                    RoleId = new Guid("CAEA4300-91D6-42F8-9DD7-80F8C9F6F88F").ToString(),
                    UserId = new Guid("72BD714F-4856-45BA-B5B7-F00649BE00DE").ToString(),
                }, 
                new IdentityUserRole<string>
                {
                    RoleId = new Guid("CAEA4300-91D6-42F8-9DD7-80F8C9F6F88F").ToString(),
                    UserId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE").ToString(),
                }
            );

            builder.Entity<Position>().HasData(
                new Position() { Id = 1, Value = "Trưởng khoa"},
                new Position() { Id = 2, Value = "Phó trưởng khoa"},
                new Position() { Id = 3, Value = "Giảng viên"},
                new Position() { Id = 4, Value = "Trưởng bộ môn"}
            );

            builder.Entity<Literacy>().HasData(
                new Literacy() { Id = 1, Value = "Cử nhân"},    
                new Literacy() { Id = 2, Value = "Thạc sĩ"},
                new Literacy() { Id = 3, Value = "Tiến sĩ"},
                new Literacy() { Id = 4, Value = "Phó giáo sư"},
                new Literacy() { Id = 5, Value = "Giáo sư"}
            );

            builder.Entity<Department>().HasData(
                new Department() { Id = "CNTT", Name = "Công Nghệ Thông Tin", CreatedDate = new DateTime(2022,06,01,00,00,00) },
                new Department() { Id = "CNHH", Name = "Công Nghệ Hóa Học", CreatedDate = new DateTime(2022, 06, 01, 00, 00, 00) },
                new Department() { Id = "CNOT", Name = "Công Nghệ Ô Tô", CreatedDate = new DateTime(2022, 06, 01, 00, 00, 00) },
                new Department() { Id = "CNCK", Name = "Cơ Khí", CreatedDate = new DateTime(2022, 06, 01, 00, 00, 00) }
            );

            builder.Entity<Personal>().HasData(
                new Personal()
                {
                    Id = "311111111111",
                    Name = "Nguyễn Quốc Khánh",
                    Avatar = "/plugins/images/users/025080010611.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Trưởng bộ môn",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenquockhanh@vui.com",
                    PhoneNumber = "0965875697"
                },
                new Personal()
                {
                    Id = "311111122222",
                    Name = "Đỗ Cao Minh",
                    Avatar = "/plugins/images/users/025080002921.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Phó trưởng khoa",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Docaominh@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111133333",
                    Name = "Hà Thị Thu Hiền",
                    Avatar = "",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Hathithuhien@vui.com",
                    PhoneNumber = "0585469852"
                },
                new Personal()
                {
                    Id = "311111144444",
                    Name = "Lê Văn Điệp",
                    Avatar = "/plugins/images/users/038075028517.JPG",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Levandiep@vui.com",
                    PhoneNumber = "0856325855"
                },
                new Personal()
                {
                    Id = "311111155555",
                    Name = "Trần Thị Hiệp",
                    Avatar = "/plugins/images/users/015176004351.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Trưởng khoa",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Tranthihiep@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111166666",
                    Name = "Đỗ Thị Hồng",
                    Avatar = "/plugins/images/users/131302862.JPG",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Dothihong@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111177777",
                    Name = "Nguyễn Ngọc Ánh",
                    Avatar = "/plugins/images/users/063397395.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenngocanh@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111199999",
                    Name = "Nguyễn Thu Hường",
                    Avatar = "/plugins/images/users/131459038.JPG",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenthuhuong@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111211111",
                    Name = "Đào Minh Sang",
                    Avatar = "/plugins/images/users/025088015041.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Daominhsang@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111222222",
                    Name = "Vũ Thu Thảo",
                    Avatar = "/plugins/images/users/025188012664.jpg",
                    Birth = new DateTime(1985, 10, 10, 0, 0, 0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Vuthuthao@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "311111233333",
                    Name = "Phạm Thu Thủy",
                    Avatar = "/plugins/images/users/034184019053.JPG",
                    Birth = new DateTime(1985, 10, 10, 0, 0, 0),
                    DepartmentId = "CNTT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Phamthuthuy@vui.com",
                    PhoneNumber = "0364859669"
                }
            );
            builder.Entity<Personal>().HasData(
                new Personal()
                {
                    Id = "111111111111",
                    Name = "Nguyễn Mạnh Tiến",
                    Avatar = "/plugins/images/users/agent.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Trưởng khoa",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenmanhtien@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111122222",
                    Name = "Nguyễn Văn An",
                    Avatar = "/plugins/images/users/agent.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Trưởng khoa",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenvanan@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111133333",
                    Name = "Bùi Đinh Nhi",
                    Avatar = "/plugins/images/users/6.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Trưởng bộ môn",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Buidinhnhi@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111144444",
                    Name = "Lê Thị Minh Hằng",                    
                    Avatar = "/plugins/images/users/8.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Lethiminhhang@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111155555",
                    Name = "Hoàng Thị Kim Vân",                    
                    Avatar = "/plugins/images/users/hritik.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Hoangthikimvan@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111166666",
                    Name = "Đàm Thị Thùy Nga",                    
                    Avatar = "/plugins/images/users/23.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Damthuynga@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "111111177777",
                    Name = "Ngô Hồng Nghĩa",                    
                    Avatar = "/plugins/images/users/54.jfif",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNHH",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Ngohongnghia@vui.com",
                    PhoneNumber = "0364859669"
                }
            );            
            builder.Entity<Personal>().HasData(
                new Personal()
                {
                    Id = "211111111111",
                    Name = "Lê Quang Vinh",
                    Avatar = "/plugins/images/users/3.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNOT",
                    Position = "Trưởng bộ môn",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Lequangvinh@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "211111122222",
                    Name = "Nguyễn Thị Quỳnh",
                    Avatar = "/plugins/images/users/3f086fe2-25fc-47e4-a861-92105f58f973.jfif",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNOT",
                    Position = "Giảng viên",
                    Gender = false,
                    Literacy = "Thạc sĩ",
                    Email = "Nguyenthiquynh@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "211111133333",
                    Name = "Trần Văn Tân",
                    Avatar = "/plugins/images/users/d4.jpg",
                    Birth = new DateTime(1985,10,10,0,0,0),
                    DepartmentId = "CNOT",
                    Position = "Giảng viên",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Tranvantan@vui.com",
                    PhoneNumber = "0364859669"
                }
            );
            builder.Entity<Personal>().HasData(
                new Personal()
                {
                    Id = "411111111111",
                    Name = "Vũ Quốc Hiến",
                    Avatar = "/plugins/images/users/3.png",
                    Birth = new DateTime(1985, 10, 10, 0, 0, 0),
                    DepartmentId = "CNCK",
                    Position = "Giảng viên",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Vuquochien@vui.com",
                    PhoneNumber = "0364859669"
                },
                new Personal()
                {
                    Id = "411111122222",
                    Name = "Phạm Ngọc Thành",
                    Avatar = "/plugins/images/users/3.png",
                    Birth = new DateTime(1985, 10, 10, 0, 0, 0),
                    DepartmentId = "CNCK",
                    Position = "Giảng viên",
                    Gender = true,
                    Literacy = "Thạc sĩ",
                    Email = "Phamngocthanh@vui.com",
                    PhoneNumber = "0364859669"
                }
            );

            builder.Entity<Field>().HasData(
                new Field() { Id = 1, Value= "Công nghệ Thông tin" },    
                new Field() { Id = 3, Value= "Kỹ thuật - Cơ khí" },
                new Field() { Id = 5, Value= "Công nghệ hóa học" }
            );

            builder.Entity<Research>().HasData(
                new Research()
                {
                    Id = "211111117777",
                    Subject = "Thiết kế chế tạo ABC XYZ tiết kiệm nhiên liệu ECORUN",
                    InstructorId = "411111122222",
                    DateStarted = new DateTime(2021, 12, 31, 0, 0, 0),
                    DateExpired = new DateTime(2022, 12, 31, 0, 0, 0),
                    Expense = 18941000,
                    Status = General.Enum.ResearchStatus.Handed,
                    Field = "Kỹ thuật - Cơ khí",
                }, 
                new Research()
                {
                    Id = "211111116666",
                    Subject = "Sản xuất ABC XYZ theo phương pháp truyền thống",
                    InstructorId = "111111166666",
                    DateStarted = new DateTime(2021, 12, 31, 0, 0, 0),
                    DateExpired = new DateTime(2022, 12, 31, 0, 0, 0),
                    Expense = 10080000,
                    Status = General.Enum.ResearchStatus.Defended,
                    Field = "Công nghệ hóa học",
                }, 
                new Research()
                {
                    Id = "21111115555",
                    Subject = "Nghiên cứu một số phương pháp ABC XYZ",
                    InstructorId = "111111177777",
                    DateStarted = new DateTime(2021, 12, 31, 0, 0, 0),
                    DateExpired = new DateTime(2022, 12, 31, 0, 0, 0),
                    Expense = 5470000,
                    Status = General.Enum.ResearchStatus.Handed,
                    Field = "Công nghệ hóa học",
                }, 
                new Research()
                {
                    Id = "21111114444",
                    Subject = "Xây dựng phần mềm tra ABZ XYZ, chứng chỉ của Trường Đại học Công nghiệp Việt Trì",
                    InstructorId = "311111155555",
                    DateStarted = new DateTime(2021,12,31,0,0,0),
                    DateExpired = new DateTime(2022,12,31,0,0,0),
                    Expense = 2570000,
                    Status = General.Enum.ResearchStatus.Handed,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "21111113333",
                    Subject = "Xây dựng Trang web ABZ XYZ của Trường Đại học Công nghiệp Việt Trì",
                    InstructorId = "311111155555",
                    DateStarted = new DateTime(2021,12,31,0,0,0),
                    DateExpired = new DateTime(2022,12,31,0,0,0),
                    Expense = 2570000,
                    Status = General.Enum.ResearchStatus.Defended,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "21111112222",
                    Subject = "Xây dựng phần mềm tra cứu văn bằng, chứng chỉ của Trường Đại học Công nghiệp Việt Trì",
                    InstructorId = "311111155555",
                    DateStarted = new DateTime(2020,12,31,0,0,0),
                    DateExpired = new DateTime(2021,12,31,0,0,0),
                    Expense = 2570000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "21111111111",
                    Subject = "Nghiên cứu một số phương pháp thu hồi silic đioxit từ vỏ trấu",
                    InstructorId = "111111177777",
                    DateStarted = new DateTime(2020,12,31,0,0,0),
                    DateExpired = new DateTime(2021,12,31,0,0,0),
                    Expense = 5470000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "111111119999",
                    Subject = "Sản xuất nước giải khát chanh leo nha đam lên men theo phương pháp truyền thống",
                    InstructorId = "111111166666",
                    DateStarted = new DateTime(2020,12,31,0,0,0),
                    DateExpired = new DateTime(2021,12,31,0,0,0),
                    Expense = 10080000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "111111118888",
                    Subject = "Thiết kế chế tạo xe tiết kiệm nhiên liệu ECORUN",
                    InstructorId = "411111122222",
                    DateStarted = new DateTime(2020,12,31,0,0,0),
                    DateExpired = new DateTime(2021,12,31,0,0,0),
                    Expense = 18941000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Kỹ thuật - Cơ khí",
                },
                new Research()
                {
                    Id = "111111117777",
                    Subject = "Nghiên cứu thiết kế, chế tạo mô hình tập lái xe ô tô ảo",
                    InstructorId = "411111111111",
                    DateStarted = new DateTime(2020,12,31,0,0,0),
                    DateExpired = new DateTime(2021,12,31,0,0,0),
                    Expense = 19950000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Kỹ thuật - Cơ khí",
                },
                new Research()
                {
                    Id = "111111116666",
                    Subject = "Nghiên cứu hoàn thiện quy trình tách chiết và xác định thành phần hóa học của tinh dầu hoa ngọc lan trồng ở Tỉnh Phú Thọ, ứng dụng sản xuất thử nghiệm nước lau sàn hương ngọc lan",
                    InstructorId = "111111155555",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 9300000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ hóa học",
                },
                new Research()
                {
                    Id = "111111115555",
                    Subject = "Xây dựng phần mềm quản lý ký túc xá Trường Đại học Công nghiệp Việt Trì",
                    InstructorId = "311111166666",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 200000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ Thông tin",
                },
                new Research()
                {
                    Id = "111111114444",
                    Subject = "Xây dựng hệ thống VoIP cho Trường Đại học Công nghiệp Việt Trì và nghiên cứu giải pháp bảo mật cho dịch vụ",
                    InstructorId = "311111155555",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 200000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ Thông tin",
                },
                new Research()
                {
                    Id = "111111113333",
                    Subject = "Nghiên cứu xây dựng phòng thực hành mô hình động cơ ô tô phục vụ công tác giảng dạy và nghiên cứu khoa học của Trường Đại học Công nghiệp Việt Trì",
                    InstructorId = "411111111111",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 37500000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Kỹ thuật - Cơ khí",
                },
                new Research()
                {
                    Id = "111111112222",
                    Subject = "Nghiên cứu chế tạo chế phẩm sinh học Bateriocin giúp tăng cường bảo quản rau củ quả",
                    InstructorId = "111111133333",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 14700000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Công nghệ hóa học",
                },   
                new Research()
                {
                    Id = "111111111111",
                    Subject = "Nghiên cứu chế tạo máy thu gom rác sinh hoạt",
                    InstructorId = "211111111111",
                    DateStarted = new DateTime(2019,12,31,0,0,0),
                    DateExpired = new DateTime(2020,12,31,0,0,0),
                    Expense = 4081000,
                    Status = General.Enum.ResearchStatus.Inspected,
                    Field = "Kỹ thuật - Cơ khí",
                }    
            );
              
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "21111112222x94d8b0ea05858fbf36c", 
                    ResearchId = "21111112222", 
                    File = "/files/21111112222/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "21111112222a1mlsk41a74ba06279e8", 
                    ResearchId = "21111112222", 
                    File = "/files/21111112222/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "21111112222a87456ea40d512f27ce0", 
                    ResearchId = "21111112222", 
                    File = "/files/21111112222/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );      
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "21111111111x94d8b0ea05858fbf36c", 
                    ResearchId = "21111111111", 
                    File = "/files/21111111111/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "21111111111a1mlsk41a74ba06279e8", 
                    ResearchId = "21111111111", 
                    File = "/files/21111111111/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "21111111111a87456ea40d512f27ce0", 
                    ResearchId = "21111111111", 
                    File = "/files/21111111111/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );      
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111119999x94d8b0ea05858fbf36c", 
                    ResearchId = "111111119999", 
                    File = "/files/111111119999/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111119999a1mlsk41a74ba06279e8", 
                    ResearchId = "111111119999", 
                    File = "/files/111111119999/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111119999a87456ea40d512f27ce0", 
                    ResearchId = "111111119999", 
                    File = "/files/111111119999/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );      
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111118888x94d8b0ea05858fbf36c", 
                    ResearchId = "111111118888", 
                    File = "/files/111111118888/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111118888a1mlsk41a74ba06279e8", 
                    ResearchId = "111111118888", 
                    File = "/files/111111118888/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111118888a87456ea40d512f27ce0", 
                    ResearchId = "111111118888", 
                    File = "/files/111111118888/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );    
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111117777x94d8b0ea05858fbf36c", 
                    ResearchId = "111111117777", 
                    File = "/files/111111117777/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111117777a1mlsk41a74ba06279e8", 
                    ResearchId = "111111117777", 
                    File = "/files/111111117777/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111117777a87456ea40d512f27ce0", 
                    ResearchId = "111111117777", 
                    File = "/files/111111117777/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );        
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111116666x94d8b0ea05858fbf36c", 
                    ResearchId = "111111116666", 
                    File = "/files/111111116666/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111116666a1mlsk41a74ba06279e8", 
                    ResearchId = "111111116666", 
                    File = "/files/111111116666/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111116666a87456ea40d512f27ce0", 
                    ResearchId = "111111116666", 
                    File = "/files/111111116666/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );      
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111115555x94d8b0ea05858fbf36c", 
                    ResearchId = "111111115555", 
                    File = "/files/111111115555/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111115555a1mlsk41a74ba06279e8", 
                    ResearchId = "111111115555", 
                    File = "/files/111111115555/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111115555a87456ea40d512f27ce0", 
                    ResearchId = "111111115555", 
                    File = "/files/111111115555/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );    
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111114444x94d8b0ea05858fbf36c", 
                    ResearchId = "111111114444", 
                    File = "/files/111111114444/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111114444a1mlsk41a74ba06279e8", 
                    ResearchId = "111111114444", 
                    File = "/files/111111114444/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111114444a87456ea40d512f27ce0", 
                    ResearchId = "111111114444", 
                    File = "/files/111111114444/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );  
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "111111113333x94d8b0ea05858fbf36c", 
                    ResearchId = "111111113333", 
                    File = "/files/111111113333/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "111111113333a1mlsk41a74ba06279e8", 
                    ResearchId = "111111113333", 
                    File = "/files/111111113333/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "111111113333a87456ea40d512f27ce0", 
                    ResearchId = "111111113333", 
                    File = "/files/111111113333/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "24e78948940a494d8b0ea05858fbf36c", 
                    ResearchId = "111111112222", 
                    File = "/files/111111112222/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "5a7719d66d8a41mlsk41a74ba06279e8", 
                    ResearchId = "111111112222", 
                    File = "/files/111111112222/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                },
                new ResearchFile() { 
                    Id = "8474ba31c552487456ea40d512f27ce0", 
                    ResearchId = "111111112222", 
                    File = "/files/111111112222/bcd301cf-5155-4a74-9a70-64077786c4a8.png",
                    FileExtend = "png",
                    Name = "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png",
                }
            );
            builder.Entity<ResearchFile>().HasData(
                new ResearchFile() { 
                    Id = "24ee7418940a494d8b0ea05858fbf36c", 
                    ResearchId = "111111111111", 
                    File = "/files/111111111111/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx",
                    FileExtend = "docx",
                    Name = "word_Do_an-VuHuuKhanh_IN.docx",
                },
                new ResearchFile() { 
                    Id = "5a7719d66d8a41c4a241a74ba06279e8", 
                    ResearchId = "111111111111", 
                    File = "/files/111111111111/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf",
                    FileExtend = "pdf",
                    Name = "quyet dinh 1063-31.12.19.pdf",
                }
            );

            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "211111116666",
                    MemberId = "111111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "211111116666",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "211111116666",
                    MemberId = "111111166666",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "211111116666",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "21111113333",
                    MemberId = "111111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "21111113333",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "21111113333",
                    MemberId = "111111166666",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "21111113333",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "21111112222",
                    MemberId = "111111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "21111112222",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "21111112222",
                    MemberId = "111111166666",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "21111112222",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "21111111111",
                    MemberId = "111111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "21111111111",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "21111111111",
                    MemberId = "111111144444",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "21111111111",
                    MemberId = "111111177777",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111119999",
                    MemberId = "111111122222",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111119999",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111119999",
                    MemberId = "111111144444",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111119999",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111118888",
                    MemberId = "411111122222",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111118888",
                    MemberId = "211111111111",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111118888",
                    MemberId = "211111122222",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111118888",
                    MemberId = "211111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111117777",
                    MemberId = "411111122222",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111117777",
                    MemberId = "211111111111",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111117777",
                    MemberId = "211111122222",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111117777",
                    MemberId = "211111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111116666",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111116666",
                    MemberId = "111111166666",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111116666",
                    MemberId = "111111177777",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111116666",
                    MemberId = "111111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111115555",
                    MemberId = "311111155555",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111115555",
                    MemberId = "311111166666",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111115555",
                    MemberId = "311111144444",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111115555",
                    MemberId = "311111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111114444",
                    MemberId = "311111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111114444",
                    MemberId = "311111122222",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111114444",
                    MemberId = "311111144444",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111114444",
                    MemberId = "311111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111113333",
                    MemberId = "411111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111113333",
                    MemberId = "411111122222",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111113333",
                    MemberId = "211111111111",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111113333",
                    MemberId = "211111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111111111",
                    MemberId = "411111111111",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111111111",
                    MemberId = "411111122222",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111111111",
                    MemberId = "211111122222",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111111111",
                    MemberId = "211111133333",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );
            builder.Entity<CouncilMember>().HasData(
                new CouncilMember()
                {
                    ResearchId = "111111112222",
                    MemberId = "111111155555",
                    Position = General.Enum.PositionCouncil.Chairman
                },
                new CouncilMember()
                {
                    ResearchId = "111111112222",
                    MemberId = "111111166666",
                    Position = General.Enum.PositionCouncil.Commissioner1
                },
                new CouncilMember()
                {
                    ResearchId = "111111112222",
                    MemberId = "111111177777",
                    Position = General.Enum.PositionCouncil.Commissioner2
                },
                new CouncilMember()
                {
                    ResearchId = "111111112222",
                    MemberId = "111111111111",
                    Position = General.Enum.PositionCouncil.Secretary
                }
            );

            builder.Entity<ResearchAcceptance>().HasData(
                new ResearchAcceptance()
                {
                    ResearchId = "111111111111",
                    Score = 7.7,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111112222",
                    Score = 8.7,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111113333",
                    Score = 9.0,
                    Rating = General.Enum.AcceptanceRate.Excellent,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111114444",
                    Score = 9.0,
                    Rating = General.Enum.AcceptanceRate.Excellent,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111115555",
                    Score = 9.0,
                    Rating = General.Enum.AcceptanceRate.Excellent,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111116666",
                    Score = 6.9,
                    Rating = General.Enum.AcceptanceRate.Pass,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111117777",
                    Score = 6.9,
                    Rating = General.Enum.AcceptanceRate.Pass,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111118888",
                    Score = 6.9,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "111111119999",
                    Score = 7.9,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "21111111111",
                    Score = 7.9,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                },
                new ResearchAcceptance()
                {
                    ResearchId = "21111112222",
                    Score = 7.9,
                    Rating = General.Enum.AcceptanceRate.Good,
                    Acceptance = General.Enum.AcceptanceStatus.Pass
                }
            );
            //Add-Migration 001 -OutputDir "Data/Migrations"
        }
    }
}
