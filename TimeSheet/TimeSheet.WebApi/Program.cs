using Microsoft.EntityFrameworkCore;
using TimeSheet.Application.Services;
using TimeSheet.Data.Data;
using TimeSheet.Data.Repositories;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database context (MyContex)
builder.Services.AddDbContext<DatabaseContex>(options =>
{
    options.UseMySql("Server=localhost;Database=VegaSourcing;User=ognjen;Password=ognjen34;", new MySqlServerVersion(new Version(8, 0, 21)));
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkHourRepository, WorkHourRepository>();
builder.Services.AddScoped<IWorkHourService, WorkHourService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();


var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
