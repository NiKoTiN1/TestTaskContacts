using TestTaskContacts.DataAccess;
using Microsoft.EntityFrameworkCore;
using TestTaskContacts.DataAccess.Interfaces;
using TestTaskContacts.DataAccess.Repositories;
using TestTaskContacts.Services.Interfaces;
using TestTaskContacts.Services.Services;
using TestTaskContacts.VeiwModels.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddAutoMapper(typeof(ContactProfile));

builder.Services.AddTransient(typeof(IContactRepository), typeof(ContactRepository));
builder.Services.AddTransient<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
