using Microsoft.EntityFrameworkCore;
using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Repository;
using CompanyManagement.Logic.Interfaces;
using CompanyManagement.Logic;

namespace CompanyManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();
            builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
            builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();

            builder.Services.AddScoped<ICompanyLogic, CompanyLogic>();
            builder.Services.AddScoped<IDepartmentLogic, DepartmentLogic>();
            builder.Services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}