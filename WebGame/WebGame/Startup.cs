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
using WebGame.Api.Data;
using WebGame.Api.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebGame.Common;
using Microsoft.AspNetCore.Identity;
using WebGame.Database.Model;




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

            services.AddOptions();
            services.AddLogging();


            services.AddSingleton<IAccountService, AccountService>();
            services.AddTransient<IJwtTokenHelper, JwtTokenHelper>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<TokenManagerMiddleware>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDistributedSqlServerCache(r => { r.ConnectionString = Configuration["redis:connectionString"]; });

            var jwtSection = Configuration.GetSection("jwt");
            var jwtOptions = new JwtOptions();
            jwtSection.Bind(jwtOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                             //укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                             //строка, представляющая издателя
                            ValidIssuer = jwtOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = jwtOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.KEY)),
                             //валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.Configure<JwtOptions>(jwtSection);

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
                            new string[] {}
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

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthentication();

            app.UseMiddleware<TokenManagerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
