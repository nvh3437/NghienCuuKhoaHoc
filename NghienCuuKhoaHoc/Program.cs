using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Services.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add-Migration 001 -OutputDir "Data/Migrations"
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(option =>{
    option.Password.RequireDigit = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequiredLength = 4;
    option.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(configure =>
{
    configure.AccessDeniedPath = "/Denied";
    configure.LoginPath = "/Login";
    configure.LogoutPath = "/Login/Logout";
});

//Add MailInfo EmailSender
builder.Services.AddOptions();
builder.Services.Configure<MailInfo>(builder.Configuration.GetSection("MailInfo"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IPersonalService, PersonalService>();
builder.Services.AddTransient<IResearchService, ResearchService>();
builder.Services.AddTransient<ICouncilMemberService, CouncilMemberService>();
builder.Services.AddTransient<IAcceptanceService, AcceptanceService>();
builder.Services.AddTransient<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Denied");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
