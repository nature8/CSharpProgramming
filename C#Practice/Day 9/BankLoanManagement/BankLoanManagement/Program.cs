
/*using BankLoanManagement.API.Data;
using BankLoanManagement.API.Repositories.Implementations;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Implementations;
using BankLoanManagement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            //Registering the repositories and services
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
*/

using BankLoanManagement.API.Data;
using BankLoanManagement.API.Repositories.Implementations;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Implementations;
using BankLoanManagement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Connection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Controllers
            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency Injection -> Customer
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // DI -> LoanType
            builder.Services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            builder.Services.AddScoped<ILoanTypeService, LoanTypeService>();

            // DI -> LoanApplication
            builder.Services.AddScoped<ILoanApplicationRepository, LoanApplicationRepository>();
            builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();

            // DI -> Loan
            builder.Services.AddScoped<ILoanRepository, LoanRepository>();
            builder.Services.AddScoped<ILoanService, LoanService>();

            // DI -> EMI
            builder.Services.AddScoped<IEMIRepository, EMIRepository>();
            builder.Services.AddScoped<IEMIService, EMIService>();

            var app = builder.Build();

            // Swagger Middleware
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