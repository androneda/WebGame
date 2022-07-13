using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebGame.Core.Services;
using WebGame.Core.Services.Interfaces;
using WebGame.Database;
using WebGame.Database.Repositories;
using WebGame.Database.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebGame.Api.Data;

namespace WebGame.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebGame", Version = "v1" });
            });
            services.AddEntityFrameworkNpgsql().AddDbContext<WebGameDBContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("WebGameData")));
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IHeroService, HeroService>();
            services.AddScoped<IAmmunitionRepository, AmmunitionRepository>();
            services.AddScoped<IAmmunitionService, AmmunitionService>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddAutoMapper(typeof(AppMappingProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebGame v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
