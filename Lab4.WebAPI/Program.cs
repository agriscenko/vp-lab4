using Microsoft.EntityFrameworkCore;
using Lab2.DataAccess;
using Lab2.DataAccess.Interfaces;
using Lab2.DataAccess.Services;

namespace Lab4.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var dataDir = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "Lab2.DataAccess"));
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);

            var cs = builder.Configuration.GetConnectionString("DepartmentDatabase")
                     ?? throw new InvalidOperationException("Missing ConnectionStrings:DepartmentDatabase");
            if (cs.StartsWith("\"") && cs.EndsWith("\"")) cs = cs.Trim('"');

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<DepartmentDbContext>(o => o.UseSqlServer(cs));

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
