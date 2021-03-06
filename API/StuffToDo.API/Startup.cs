using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Missions.API.Mock.Shared.Business;
using Missions.API.Mock.Shared.Data.Adapters;
using Missions.Common.Lib.Data.Adapters;
using StuffToDo.API.Lib.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Users.API.Mock.Shared.Services.Authentication;

namespace StuffToDo.API
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
            services.AddControllers();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IMissionService, MissionService>();
            services.AddScoped<IMissionContainer, MissionContainer>();
            services.AddScoped<IMissionsDbAdapter, MissionsDbAdapter>();
            services.AddScoped<IBaseDbAdapter, BaseDbAdapter>();
            services.AddSingleton<IAuthenticationService>(new JwtAuthenticationService(_PrivateKey));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_PrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(o =>
            {
                o.AddPolicy
                (
                    "MyCorsPolicy",
                    b => b.WithOrigins
                    (
                        "http://localhost:4200",
                        "localhost:4200"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StuffToDo.API", Version = "v1" });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StuffToDo.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Fields
        // HACK safety - private key should not be hardcoded
        private const string _PrivateKey = "super_private_key";
        #endregion
    }
}
