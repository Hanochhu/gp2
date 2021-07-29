using gp2.Models;
using gp2.IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Services;
using gp2.Controllers;
using AutoMapper;
using gp2.DTO;
using gp2.Extension;
using gp2.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace gp2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            
            //services.AddIdentityCore<IdentityUser,UserManager>().AddEntityFrameworkStores<Gp2Context>();

            //注入Jwt
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var secretByte = Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]);
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Authentication:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["Authentication:Audience"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(secretByte)

                    };
                });


            services.AddControllers();
            // 注入dbcontext
            services.AddDbContext<Gp2Context>(options =>
            {
                options.UseMySql("server=127.0.0.1;user id=root;password=123;database=gp2", ServerVersion.Parse("5.5.62-mysql"));
            });

            //配置跨域
            services.AddCors(option =>
            option.AddPolicy("cors",
            policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[] { "http://localhost:8080" }))
            );

            //注入仓储
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<UserRepository>();
            services.AddScoped<SpotcRepository>();
            services.AddScoped<StrategyRepository>();
            services.AddScoped<ActcollectionRepository>();
            services.AddScoped<ActivityRepository>();

            //注入服务类
            services.AddScoped<IActcollectionService, ActcollectionService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IScenicspotService, ScenicspotService>();
            services.AddScoped<IScenicviewService, ScenicviewService>();
            services.AddScoped<ISpotcollectionService, SpotcollectionService>();
            services.AddScoped<ISpotcollectionService, SpotcollectionService>();
            services.AddScoped<IStacollectionService, StacollectionService>();
            services.AddScoped<IStrategyService, StrategyService>();
            services.AddScoped<IUserService, UserService>();

            //注入AutoMapper
            services.AddLoaclAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gp2", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gp2 v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
