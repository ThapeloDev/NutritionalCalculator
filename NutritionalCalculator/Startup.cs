using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Policies;
using RolesClass = NutritionalCalculator.Classes.Roles;
using FoodsCategoriesClass = NutritionalCalculator.Classes.FoodsCategories;
using ConsumedFoodsClass = NutritionalCalculator.Classes.ConsumedFoods;
using FoodsClass = NutritionalCalculator.Classes.Foods;


namespace NutritionalCalculator
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_AllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<NutritionalCalculatorContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("connection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["UserTokenKey"])),
                    ClockSkew = TimeSpan.Zero
                });

            services.AddAuthorization(options => options.AddPolicy("AdministratorRequirement", policy => policy.Requirements.Add(new RoleAdministratorHandler())));

            services.AddMvc().AddJsonOptions(JsonConfiguration);
            services.AddScoped<IAccount, Account>();
            services.AddScoped<IToken, Token>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IRoles, RolesClass>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INutritionalCalculatorContext, NutritionalCalculatorContext>();
            services.AddScoped<IFoodsCategories, FoodsCategoriesClass>();
            services.AddScoped<IFoods, FoodsClass>();
            services.AddScoped<IConsumedFoods, ConsumedFoodsClass>();
            services.AddScoped<IResponseHandler, ResponseHandler>();
            
            services.AddCors(options => {
                options.AddPolicy(AllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void JsonConfiguration(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(AllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
