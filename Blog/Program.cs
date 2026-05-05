
using Blog.Core;
using Blog.Core.Mapping;
using Blog.Core.ServicesContract;
using Blog.Repository;
using Blog.Repository.Data.Context;
using Blog.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new BlogPostProfile()));


            var app = builder.Build();

            using var scop = app.Services.CreateScope();
            var services = scop.ServiceProvider;
            var context = services.GetRequiredService<BlogDbContext>();
            await context.Database.MigrateAsync();
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
