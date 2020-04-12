using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealershipProject.Core.Domain;
using CarDealershipProject.Repositories.Implementations;
using CarDealershipProject.Repositories.Interfaces;
using CarDealershipProject.Services.Implementations;
using CarDealershipProject.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CarDealershipProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Below we bind our appsettings to our ServiceOptions
            services.Configure<ServiceOptions>(Configuration);
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CarDealershipProject.Mapping.DealershipMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //AddCors allows other websites to gain access to the API
            services.AddCors(
                options =>
                {
                    options.AddDefaultPolicy(
                        builder => {

                            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                        });

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
