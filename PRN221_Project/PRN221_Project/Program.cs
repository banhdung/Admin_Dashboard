﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

using PRN221_Project.Services;
using PRN221_Project.Services.IService;


namespace PRN221_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var serviceColection = new ServiceCollection();

            builder.Services.AddScoped<IProductCategoryService,ProductCategoryService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<POSTContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/admin"))
                {
                    if (context.Request.Cookies.TryGetValue("Role", out var roleValue))
                    {
                        if (roleValue != "1")
                        {
                            context.Response.Redirect("/staff");
                            return;
                        }
                    }
                    else
                    {
                        context.Response.Redirect("/login");
                        return;
                    }
                }

                await next.Invoke();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            
            
            app.MapRazorPages();
         
           
            app.Run();
        }
    }
}