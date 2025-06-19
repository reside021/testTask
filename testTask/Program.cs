using Microsoft.EntityFrameworkCore;
using testTask.DB;
using FluentValidation;
using FluentValidation.AspNetCore;
using testTask.Validators;
using testTask.Repositories;
using MapsterMapper;
using Mapster;
using System.Reflection;

namespace testTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>(opt => 
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<IMapper, ServiceMapper>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseExceptionHandler("/Error");

            app.UseRouting();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Order}/{action=Index}");


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }

                app.Run();
        }
    }
}
