using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebGame.Api.Data;
using WebGame.Common;
using WebGame.Core.Services;
using WebGame.Core.Services.Interfaces;
using WebGame.Database;
using WebGame.Database.Repositories;
using WebGame.Database.Repositories.Interfaces;

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

            RegisterConfig<AuthOptions>(services);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MySuperSecret_SecretKey123")),
                            ValidateIssuerSigningKey = true
                        };
                    });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "WebGame", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            System.Array.Empty<string>()
                    }
                });
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

            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IRaceService, RaceService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();

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

            //app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseRouting();

            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterConfig<T>(IServiceCollection services) where T : class
        {
            services.Configure<T>(Configuration.GetSection(typeof(T).Name));
        }
    }
}
