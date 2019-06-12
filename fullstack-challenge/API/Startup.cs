using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Core.Services;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Services.Models;
using Core.AutoMapper;

namespace API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddMvc();
            services.AddAuthorization();

            services.AddAuthentication("Bearer")
                        .AddJwtBearer("Bearer", options => 
                        {
                            options.Authority = "http://localhost:5002";
                            options.RequireHttpsMetadata = false;
                            options.Audience = "fscapi";
                        });

            ConfigureDependencyInjection(services);
            ConfigureAutoMapper(services);
        }

        private void ConfigureDependencyInjection(IServiceCollection services){
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IPlanetService, PlanetService>();
            services.AddTransient<ISpeciesService, SpeciesService>();
        }

        private void ConfigureAutoMapper(IServiceCollection services){
            var mapper = AutoMapperConfiguration.Configure();
            services.AddSingleton(mapper);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowAnyOrigin");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}