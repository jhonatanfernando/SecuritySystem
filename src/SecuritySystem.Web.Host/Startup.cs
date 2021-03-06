using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecuritySystem.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SecuritySystem.Core.Repositories;
using SecuritySystem.EntityFrameworkCore.Repositories;
using SecuritySystem.Core.Models;
using System;
using SecuritySystem.Application.Services;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.KeyCard.Dto;
using SecuritySystem.Application.MotionSensor.Dto;
using SecuritySystem.Application.Services.ControlAccess;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SecuritySystem.Application.Services.Door;
using SecuritySystem.Application.Services.KeyCard;

namespace SecuritySystem.Web.Host
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

            services.AddDbContext<SecuritySystemDbContext>(
                         options => options.UseSqlServer("name=ConnectionStrings:Default").UseLazyLoadingProxies()
                                           .ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

            services.AddScoped<IRepositoryBase<Door, Guid>, RepositoryBase<Door, Guid>>();
            services.AddScoped<IRepositoryBase<KeyCard, Guid>, RepositoryBase<KeyCard, Guid>>();
            services.AddScoped<IRepositoryBase<MotionSensor, Guid>, RepositoryBase<MotionSensor, Guid>>();
            services.AddScoped<IRepositoryBase<ControlAccess, long>, RepositoryBase<ControlAccess, long>>();
            services.AddScoped<IRepositoryBase<DoorLogActivity, long>, RepositoryBase<DoorLogActivity, long>>();

            services.AddScoped<IDoorAppService, SecuritySystem.Application.Services.Door.DoorAppService>();
            services.AddScoped<IKeyCardAppService, SecuritySystem.Application.Services.KeyCard.KeyCardAppService>();
            services.AddScoped<IAppService<MotionSensorDto, MotionSensorInsertDto, Guid>, SecuritySystem.Application.Services.MotionSensor.MotionSensorAppService>();
            services.AddScoped<IControlAccessAppService, SecuritySystem.Application.Services.ControlAccess.ControlAccessAppService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SecuritySystemDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
