
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Project
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
            builder.Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Def"));
                });

            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            // here we use the AddIdentity for use userManager , and we use AddEntityFrameworkStores
            // why we add .AddEntityFreameworkStores : because we are use Interfaces and implementation we are used , the interfaces and implementation is inside the userManager
            // so we cannot use it without .AddEntityFreameworkStores to add it's interfaces and implementations
            builder.Services.AddIdentity<Users , IdentityRole<int>>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = false;
                //option.Password.RequiredUniqueChars = 0; // dosn't matter i think
            }).AddEntityFrameworkStores<AppDbContext>();

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
