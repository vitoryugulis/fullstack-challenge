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
using fullstack_challenge.Services;
using AutoMapper;
using fullstack_challenge.Entities;
using fullstack_challenge.Services.Interfaces;
using fullstack_challenge.Services.Models;

namespace fullstack_challenge
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
            services.AddMvc();

            ConfigureDependencyInjection(services);
            ConfigureAutoMapper();
        }

        private void ConfigureDependencyInjection(IServiceCollection services){
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IPlanetService, PlanetService>();
        }

        private void ConfigureAutoMapper(){
            Mapper.Initialize(cfg => cfg.CreateMap<SwapiPerson, Person>());
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}