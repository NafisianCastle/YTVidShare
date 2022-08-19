using AspNetCoreRateLimit;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using VideoSharingService.Configurations;
using VideoSharingService.Data;
using VideoSharingService.Data.IRepository;
using VideoSharingService.Data.Repository;
using VideoSharingService.Services;

namespace VideoSharingService
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
            services.AddDbContext<VidShareDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));

            });
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJwt(Configuration);
            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(opt =>
            {   
                opt.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint ="*",
                        Limit=1,
                        Period="1s"
                    }
                };
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            services.AddHttpContextAccessor();

            services.AddResponseCaching();
            services.AddHttpCacheHeaders(
                (expirationOpt) =>
                {
                    expirationOpt.MaxAge = 65;
                    expirationOpt.CacheLocation = CacheLocation.Private;
                }, (validationOpt) =>
                {
                    validationOpt.MustRevalidate = true;
                }
                );

            services.AddCors(c =>
            {
                //c.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                var frontendUrl = Configuration.GetValue<string>("frontend_url");
                c.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAutoMapper(typeof(MapperInitializer));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager,AuthManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoSharingService", Version = "v1" });
            });

            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 120
                });
            }).AddNewtonsoftJson(op =>
            {
                op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoSharingService v1"));
            }

            app.UseHttpsRedirection();

            //app.UseCors("AllowAll");
            app.UseCors();

            app.UseResponseCaching();
            app.UseHttpCacheHeaders();
            app.UseIpRateLimiting();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name:"default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}"
                //    );
                endpoints.MapControllers();
            });


        }
    }
}
