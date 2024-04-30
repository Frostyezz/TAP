
using DataLayer;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddDbContext<MyDbContext>();

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

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MyDbContext>();
                context.Database.Migrate();
                Seeder.Seed(context);
            }

            app.Run();
        }
    }
}
