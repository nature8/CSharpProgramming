
//using Microsoft.EntityFrameworkCore;

//using EmployeeLeaveManagement.Data;

//namespace EmployeeLeaveManagement
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();

//            builder.Services.AddEndpointsApiExplorer();

//            builder.Services.AddSwaggerGen();

//            builder.Services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//            builder.Services.AddControllers();
//            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//            builder.Services.AddOpenApi();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.MapOpenApi();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}


using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Repositories;
using EmployeeLeaveManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            // Middleware
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