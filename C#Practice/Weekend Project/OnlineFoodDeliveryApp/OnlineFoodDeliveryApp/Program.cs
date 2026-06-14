
//using Microsoft.EntityFrameworkCore;
//using OnlineFoodOrder.API.Data;

//namespace OnlineFoodDeliveryApp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//            builder.Services.AddOpenApi();

//            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
//            builder.Configuration.GetConnectionString("DefaultConnection")));

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


using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliveryApp.Repositories.Implementations;
using OnlineFoodDeliveryApp.Repositories.Interfaces;
using OnlineFoodDeliveryApp.Services.Implementations;
using OnlineFoodDeliveryApp.Services.Interfaces;
using OnlineFoodOrder.API.Data;

namespace OnlineFoodDeliveryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services

            // Controllers
            builder.Services.AddControllers();

   
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database Context (EF Core)
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );


            // DI -> Customer
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // DI -> Category
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            // DI -> FoodItem 
            builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            builder.Services.AddScoped<IFoodItemService, FoodItemService>();

            // DI -> Order
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            // DI -> OrderDetail
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();




            #endregion

            var app = builder.Build();

            #region Middleware Pipeline

            // Swagger UI (only in development)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // HTTPS redirect
            app.UseHttpsRedirection();

            // Authorization
            app.UseAuthorization();

            // Map controllers
            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}