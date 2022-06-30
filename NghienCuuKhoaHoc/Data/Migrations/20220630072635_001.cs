using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NghienCuuKhoaHoc.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Literacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(12)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Birth = table.Column<DateTime>(type: "date", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", nullable: true),
                    Literacy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personals_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(12)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    InstructorId = table.Column<string>(type: "varchar(12)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Expense = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researches_Personals_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CouncilMembers",
                columns: table => new
                {
                    ResearchId = table.Column<string>(type: "varchar(12)", nullable: false),
                    MemberId = table.Column<string>(type: "varchar(12)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilMembers", x => new { x.ResearchId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_CouncilMembers_Personals_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouncilMembers_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchAcceptances",
                columns: table => new
                {
                    ResearchId = table.Column<string>(type: "varchar(12)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Acceptance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchAcceptances", x => x.ResearchId);
                    table.ForeignKey(
                        name: "FK_ResearchAcceptances_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResearchId = table.Column<string>(type: "varchar(12)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtend = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchFiles_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { "CNCK", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ Khí" },
                    { "CNHH", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Công Nghệ Hóa Học" },
                    { "CNOT", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Công Nghệ Ô Tô" },
                    { "CNTT", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Công Nghệ Thông Tin" }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Công nghệ Thông tin" },
                    { 3, "Kỹ thuật - Cơ khí" },
                    { 5, "Công nghệ hóa học" }
                });

            migrationBuilder.InsertData(
                table: "Literacies",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Cử nhân" },
                    { 2, "Thạc sĩ" },
                    { 3, "Tiến sĩ" },
                    { 4, "Phó giáo sư" },
                    { 5, "Giáo sư" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Trưởng khoa" },
                    { 2, "Phó trưởng khoa" },
                    { 3, "Giảng viên" },
                    { 4, "Trưởng bộ môn" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caea4300-91d6-42f8-9dd7-80f8c9f6f88f", "be3bd974-69e0-4b35-9c12-69c8f1b88e1f", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69bd714f-9576-45ba-b5b7-f00649be00de", 0, "b56a45c3-6bd0-4329-a50f-ce5e07c6c369", "Ngohung3437@gmail.com", false, false, null, "Ngohung3437@gmail.com", "admin", "AQAAAAEAACcQAAAAEApay+THB20dUeNftP97CkVM+ocSsB7sDhhKdP1AYLgtKf3Wn0t3V7jHV6ekLoe8mw==", null, false, "", false, "admin" },
                    { "72bd714f-4856-45ba-b5b7-f00649be00de", 0, "de6e450d-232f-4a61-b41d-eb7dd5031d29", "Ngohung3437@gmail.com", false, false, null, "Ngohung3437@gmail.com", "admin1", "AQAAAAEAACcQAAAAEMnSjNkVA9t5SsGJFHeqsRAwe4yg+zq6bwNYUZGQjsOP3BfuY9XYkQlmgPXb5ScCPQ==", null, false, "", false, "admin1" },
                    { "72bd714f-7812-45ba-b5b7-f00649be00de", 0, "7c9b04d0-b811-4629-81d7-e3a579977ae8", "Ngohung3437@gmail.com", false, false, null, "Ngohung3437@gmail.com", "admin2", "AQAAAAEAACcQAAAAECOiD0y7EEGlGdke6IgWHESUZeIoOrDOIEi7LomNOa9Qzb5QGqcXynT2T6IkS99OVg==", null, false, "", false, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Personals",
                columns: new[] { "Id", "Avatar", "Birth", "DepartmentId", "Email", "Gender", "Literacy", "Name", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { "111111111111", "/plugins/images/users/agent.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Nguyenmanhtien@vui.com", true, "Thạc sĩ", "Nguyễn Mạnh Tiến", "0364859669", "Trưởng khoa" },
                    { "111111122222", "/plugins/images/users/agent.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Nguyenvanan@vui.com", true, "Thạc sĩ", "Nguyễn Văn An", "0364859669", "Trưởng khoa" },
                    { "111111133333", "/plugins/images/users/6.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Buidinhnhi@vui.com", false, "Thạc sĩ", "Bùi Đinh Nhi", "0364859669", "Trưởng bộ môn" },
                    { "111111144444", "/plugins/images/users/8.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Lethiminhhang@vui.com", false, "Thạc sĩ", "Lê Thị Minh Hằng", "0364859669", "Giảng viên" },
                    { "111111155555", "/plugins/images/users/hritik.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Hoangthikimvan@vui.com", false, "Thạc sĩ", "Hoàng Thị Kim Vân", "0364859669", "Giảng viên" },
                    { "111111166666", "/plugins/images/users/23.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Damthuynga@vui.com", false, "Thạc sĩ", "Đàm Thị Thùy Nga", "0364859669", "Giảng viên" },
                    { "111111177777", "/plugins/images/users/54.jfif", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNHH", "Ngohongnghia@vui.com", false, "Thạc sĩ", "Ngô Hồng Nghĩa", "0364859669", "Giảng viên" },
                    { "211111111111", "/plugins/images/users/3.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNOT", "Lequangvinh@vui.com", true, "Thạc sĩ", "Lê Quang Vinh", "0364859669", "Trưởng bộ môn" },
                    { "211111122222", "/plugins/images/users/3f086fe2-25fc-47e4-a861-92105f58f973.jfif", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNOT", "Nguyenthiquynh@vui.com", false, "Thạc sĩ", "Nguyễn Thị Quỳnh", "0364859669", "Giảng viên" },
                    { "211111133333", "/plugins/images/users/d4.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNOT", "Tranvantan@vui.com", true, "Thạc sĩ", "Trần Văn Tân", "0364859669", "Giảng viên" },
                    { "311111111111", "/plugins/images/users/025080010611.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Nguyenquockhanh@vui.com", true, "Thạc sĩ", "Nguyễn Quốc Khánh", "0965875697", "Trưởng bộ môn" },
                    { "311111122222", "/plugins/images/users/025080002921.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Docaominh@vui.com", true, "Thạc sĩ", "Đỗ Cao Minh", "0364859669", "Phó trưởng khoa" },
                    { "311111133333", "", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Hathithuhien@vui.com", false, "Thạc sĩ", "Hà Thị Thu Hiền", "0585469852", "Giảng viên" },
                    { "311111144444", "/plugins/images/users/038075028517.JPG", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Levandiep@vui.com", true, "Thạc sĩ", "Lê Văn Điệp", "0856325855", "Giảng viên" },
                    { "311111155555", "/plugins/images/users/015176004351.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Tranthihiep@vui.com", false, "Thạc sĩ", "Trần Thị Hiệp", "0364859669", "Trưởng khoa" },
                    { "311111166666", "/plugins/images/users/131302862.JPG", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Dothihong@vui.com", false, "Thạc sĩ", "Đỗ Thị Hồng", "0364859669", "Giảng viên" },
                    { "311111177777", "/plugins/images/users/063397395.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Nguyenngocanh@vui.com", false, "Thạc sĩ", "Nguyễn Ngọc Ánh", "0364859669", "Giảng viên" },
                    { "311111199999", "/plugins/images/users/131459038.JPG", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Nguyenthuhuong@vui.com", false, "Thạc sĩ", "Nguyễn Thu Hường", "0364859669", "Giảng viên" },
                    { "311111211111", "/plugins/images/users/025088015041.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Daominhsang@vui.com", false, "Thạc sĩ", "Đào Minh Sang", "0364859669", "Giảng viên" },
                    { "311111222222", "/plugins/images/users/025188012664.jpg", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Vuthuthao@vui.com", false, "Thạc sĩ", "Vũ Thu Thảo", "0364859669", "Giảng viên" },
                    { "311111233333", "/plugins/images/users/034184019053.JPG", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNTT", "Phamthuthuy@vui.com", false, "Thạc sĩ", "Phạm Thu Thủy", "0364859669", "Giảng viên" },
                    { "411111111111", "/plugins/images/users/3.png", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNCK", "Vuquochien@vui.com", true, "Thạc sĩ", "Vũ Quốc Hiến", "0364859669", "Giảng viên" },
                    { "411111122222", "/plugins/images/users/3.png", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNCK", "Phamngocthanh@vui.com", true, "Thạc sĩ", "Phạm Ngọc Thành", "0364859669", "Giảng viên" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "caea4300-91d6-42f8-9dd7-80f8c9f6f88f", "69bd714f-9576-45ba-b5b7-f00649be00de" },
                    { "caea4300-91d6-42f8-9dd7-80f8c9f6f88f", "72bd714f-4856-45ba-b5b7-f00649be00de" },
                    { "caea4300-91d6-42f8-9dd7-80f8c9f6f88f", "72bd714f-7812-45ba-b5b7-f00649be00de" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "DateExpired", "DateStarted", "Expense", "Field", "InstructorId", "Status", "Subject" },
                values: new object[,]
                {
                    { "111111111111", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4081000m, "Kỹ thuật - Cơ khí", "211111111111", 2, "Nghiên cứu chế tạo máy thu gom rác sinh hoạt" },
                    { "111111112222", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 14700000m, "Công nghệ hóa học", "111111133333", 2, "Nghiên cứu chế tạo chế phẩm sinh học Bateriocin giúp tăng cường bảo quản rau củ quả" },
                    { "111111113333", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 37500000m, "Kỹ thuật - Cơ khí", "411111111111", 2, "Nghiên cứu xây dựng phòng thực hành mô hình động cơ ô tô phục vụ công tác giảng dạy và nghiên cứu khoa học của Trường Đại học Công nghiệp Việt Trì" },
                    { "111111114444", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000m, "Công nghệ Thông tin", "311111155555", 2, "Xây dựng hệ thống VoIP cho Trường Đại học Công nghiệp Việt Trì và nghiên cứu giải pháp bảo mật cho dịch vụ" },
                    { "111111115555", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000m, "Công nghệ Thông tin", "311111166666", 2, "Xây dựng phần mềm quản lý ký túc xá Trường Đại học Công nghiệp Việt Trì" },
                    { "111111116666", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 9300000m, "Công nghệ hóa học", "111111155555", 2, "Nghiên cứu hoàn thiện quy trình tách chiết và xác định thành phần hóa học của tinh dầu hoa ngọc lan trồng ở Tỉnh Phú Thọ, ứng dụng sản xuất thử nghiệm nước lau sàn hương ngọc lan" },
                    { "111111117777", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 19950000m, "Kỹ thuật - Cơ khí", "411111111111", 2, "Nghiên cứu thiết kế, chế tạo mô hình tập lái xe ô tô ảo" },
                    { "111111118888", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 18941000m, "Kỹ thuật - Cơ khí", "411111122222", 2, "Thiết kế chế tạo xe tiết kiệm nhiên liệu ECORUN" },
                    { "111111119999", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10080000m, "Công nghệ hóa học", "111111166666", 2, "Sản xuất nước giải khát chanh leo nha đam lên men theo phương pháp truyền thống" },
                    { "21111111111", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5470000m, "Công nghệ hóa học", "111111177777", 2, "Nghiên cứu một số phương pháp thu hồi silic đioxit từ vỏ trấu" },
                    { "211111116666", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10080000m, "Công nghệ hóa học", "111111166666", 1, "Sản xuất ABC XYZ theo phương pháp truyền thống" },
                    { "211111117777", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 18941000m, "Kỹ thuật - Cơ khí", "411111122222", 0, "Thiết kế chế tạo ABC XYZ tiết kiệm nhiên liệu ECORUN" },
                    { "21111112222", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2570000m, "Công nghệ hóa học", "311111155555", 2, "Xây dựng phần mềm tra cứu văn bằng, chứng chỉ của Trường Đại học Công nghiệp Việt Trì" },
                    { "21111113333", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2570000m, "Công nghệ hóa học", "311111155555", 1, "Xây dựng Trang web ABZ XYZ của Trường Đại học Công nghiệp Việt Trì" },
                    { "21111114444", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2570000m, "Công nghệ hóa học", "311111155555", 0, "Xây dựng phần mềm tra ABZ XYZ, chứng chỉ của Trường Đại học Công nghiệp Việt Trì" },
                    { "21111115555", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5470000m, "Công nghệ hóa học", "111111177777", 0, "Nghiên cứu một số phương pháp ABC XYZ" }
                });

            migrationBuilder.InsertData(
                table: "CouncilMembers",
                columns: new[] { "MemberId", "ResearchId", "Position" },
                values: new object[,]
                {
                    { "211111122222", "111111111111", 2 },
                    { "211111133333", "111111111111", 3 },
                    { "411111111111", "111111111111", 0 },
                    { "411111122222", "111111111111", 1 },
                    { "111111111111", "111111112222", 3 },
                    { "111111155555", "111111112222", 0 },
                    { "111111166666", "111111112222", 1 },
                    { "111111177777", "111111112222", 2 },
                    { "211111111111", "111111113333", 2 },
                    { "211111133333", "111111113333", 3 },
                    { "411111111111", "111111113333", 0 },
                    { "411111122222", "111111113333", 1 },
                    { "311111111111", "111111114444", 0 },
                    { "311111122222", "111111114444", 1 },
                    { "311111133333", "111111114444", 3 },
                    { "311111144444", "111111114444", 2 },
                    { "311111133333", "111111115555", 3 },
                    { "311111144444", "111111115555", 2 },
                    { "311111155555", "111111115555", 0 },
                    { "311111166666", "111111115555", 1 },
                    { "111111133333", "111111116666", 3 },
                    { "111111155555", "111111116666", 0 },
                    { "111111166666", "111111116666", 1 },
                    { "111111177777", "111111116666", 2 },
                    { "211111111111", "111111117777", 1 },
                    { "211111122222", "111111117777", 2 },
                    { "211111133333", "111111117777", 3 },
                    { "411111122222", "111111117777", 0 },
                    { "211111111111", "111111118888", 1 },
                    { "211111122222", "111111118888", 2 },
                    { "211111133333", "111111118888", 3 },
                    { "411111122222", "111111118888", 0 },
                    { "111111122222", "111111119999", 0 },
                    { "111111133333", "111111119999", 1 },
                    { "111111144444", "111111119999", 2 },
                    { "111111155555", "111111119999", 3 },
                    { "111111111111", "21111111111", 0 },
                    { "111111133333", "21111111111", 1 },
                    { "111111144444", "21111111111", 2 },
                    { "111111177777", "21111111111", 3 },
                    { "111111111111", "211111116666", 0 },
                    { "111111133333", "211111116666", 1 }
                });

            migrationBuilder.InsertData(
                table: "CouncilMembers",
                columns: new[] { "MemberId", "ResearchId", "Position" },
                values: new object[,]
                {
                    { "111111155555", "211111116666", 3 },
                    { "111111166666", "211111116666", 2 },
                    { "111111111111", "21111112222", 0 },
                    { "111111133333", "21111112222", 1 },
                    { "111111155555", "21111112222", 3 },
                    { "111111166666", "21111112222", 2 },
                    { "111111111111", "21111113333", 0 },
                    { "111111133333", "21111113333", 1 },
                    { "111111155555", "21111113333", 3 },
                    { "111111166666", "21111113333", 2 }
                });

            migrationBuilder.InsertData(
                table: "ResearchAcceptances",
                columns: new[] { "ResearchId", "Acceptance", "Rating", "Score" },
                values: new object[,]
                {
                    { "111111111111", 0, 1, 7.7000000000000002 },
                    { "111111112222", 0, 1, 8.6999999999999993 },
                    { "111111113333", 0, 0, 9.0 },
                    { "111111114444", 0, 0, 9.0 },
                    { "111111115555", 0, 0, 9.0 },
                    { "111111116666", 0, 2, 6.9000000000000004 },
                    { "111111117777", 0, 2, 6.9000000000000004 },
                    { "111111118888", 0, 1, 6.9000000000000004 },
                    { "111111119999", 0, 1, 7.9000000000000004 },
                    { "21111111111", 0, 1, 7.9000000000000004 },
                    { "21111112222", 0, 1, 7.9000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "ResearchFiles",
                columns: new[] { "Id", "File", "FileExtend", "Name", "ResearchId" },
                values: new object[,]
                {
                    { "111111113333a1mlsk41a74ba06279e8", "/files/111111113333/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111113333" },
                    { "111111113333a87456ea40d512f27ce0", "/files/111111113333/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111113333" },
                    { "111111113333x94d8b0ea05858fbf36c", "/files/111111113333/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111113333" },
                    { "111111114444a1mlsk41a74ba06279e8", "/files/111111114444/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111114444" },
                    { "111111114444a87456ea40d512f27ce0", "/files/111111114444/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111114444" },
                    { "111111114444x94d8b0ea05858fbf36c", "/files/111111114444/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111114444" },
                    { "111111115555a1mlsk41a74ba06279e8", "/files/111111115555/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111115555" },
                    { "111111115555a87456ea40d512f27ce0", "/files/111111115555/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111115555" },
                    { "111111115555x94d8b0ea05858fbf36c", "/files/111111115555/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111115555" },
                    { "111111116666a1mlsk41a74ba06279e8", "/files/111111116666/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111116666" },
                    { "111111116666a87456ea40d512f27ce0", "/files/111111116666/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111116666" },
                    { "111111116666x94d8b0ea05858fbf36c", "/files/111111116666/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111116666" },
                    { "111111117777a1mlsk41a74ba06279e8", "/files/111111117777/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111117777" },
                    { "111111117777a87456ea40d512f27ce0", "/files/111111117777/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111117777" },
                    { "111111117777x94d8b0ea05858fbf36c", "/files/111111117777/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111117777" },
                    { "111111118888a1mlsk41a74ba06279e8", "/files/111111118888/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111118888" },
                    { "111111118888a87456ea40d512f27ce0", "/files/111111118888/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111118888" },
                    { "111111118888x94d8b0ea05858fbf36c", "/files/111111118888/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111118888" },
                    { "111111119999a1mlsk41a74ba06279e8", "/files/111111119999/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111119999" },
                    { "111111119999a87456ea40d512f27ce0", "/files/111111119999/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111119999" },
                    { "111111119999x94d8b0ea05858fbf36c", "/files/111111119999/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111119999" }
                });

            migrationBuilder.InsertData(
                table: "ResearchFiles",
                columns: new[] { "Id", "File", "FileExtend", "Name", "ResearchId" },
                values: new object[,]
                {
                    { "21111111111a1mlsk41a74ba06279e8", "/files/21111111111/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "21111111111" },
                    { "21111111111a87456ea40d512f27ce0", "/files/21111111111/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "21111111111" },
                    { "21111111111x94d8b0ea05858fbf36c", "/files/21111111111/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "21111111111" },
                    { "21111112222a1mlsk41a74ba06279e8", "/files/21111112222/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "21111112222" },
                    { "21111112222a87456ea40d512f27ce0", "/files/21111112222/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "21111112222" },
                    { "21111112222x94d8b0ea05858fbf36c", "/files/21111112222/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "21111112222" },
                    { "24e78948940a494d8b0ea05858fbf36c", "/files/111111112222/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111112222" },
                    { "24ee7418940a494d8b0ea05858fbf36c", "/files/111111111111/811e5df4-311a-47b9-afd8-dc8a4b287e25.docx", "docx", "word_Do_an-VuHuuKhanh_IN.docx", "111111111111" },
                    { "5a7719d66d8a41c4a241a74ba06279e8", "/files/111111111111/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111111111" },
                    { "5a7719d66d8a41mlsk41a74ba06279e8", "/files/111111112222/8afc584f-e895-46ba-8e8b-999c637c87b9.pdf", "pdf", "quyet dinh 1063-31.12.19.pdf", "111111112222" },
                    { "8474ba31c552487456ea40d512f27ce0", "/files/111111112222/bcd301cf-5155-4a74-9a70-64077786c4a8.png", "png", "#ireland #flower #flowers #girl #tumblr #ireland #tumblrgirl #travel #mexican #blogger (1).png", "111111112222" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouncilMembers_MemberId",
                table: "CouncilMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CouncilMembers_Position",
                table: "CouncilMembers",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Id",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Id",
                table: "Fields",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Literacies_Id",
                table: "Literacies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_DepartmentId",
                table: "Personals",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_Id",
                table: "Personals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Id",
                table: "Positions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAcceptances_Acceptance",
                table: "ResearchAcceptances",
                column: "Acceptance");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAcceptances_Rating",
                table: "ResearchAcceptances",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAcceptances_ResearchId",
                table: "ResearchAcceptances",
                column: "ResearchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAcceptances_Score",
                table: "ResearchAcceptances",
                column: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_DateExpired",
                table: "Researches",
                column: "DateExpired");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_DateStarted",
                table: "Researches",
                column: "DateStarted");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_Expense",
                table: "Researches",
                column: "Expense");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_Field",
                table: "Researches",
                column: "Field");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_InstructorId",
                table: "Researches",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_Status",
                table: "Researches",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchFiles_ResearchId",
                table: "ResearchFiles",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouncilMembers");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Literacies");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ResearchAcceptances");

            migrationBuilder.DropTable(
                name: "ResearchFiles");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
