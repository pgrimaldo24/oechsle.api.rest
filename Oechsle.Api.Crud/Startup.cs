using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.CrossCutting.IoC;
using Oechsle.Api.Crud.Extensions;
using Oechsle.Api.Infraestructure.Implementations.Base;
using Oechsle.Api.Infraestructure.Implementations.Data;
using Oechsle.Api.Infraestructure.Interfaces.Base;
using Oechsle.Api.Infraestructure.Interfaces.Data;
using System;

namespace Oechsle.Api.Crud
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        { 
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.AddServicesInAssembly(Configuration);

            services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.Configure<AppSetting>(appSettingsSection);
            services.AddSingleton(x => x.GetService<IOptions<AppSetting>>().Value);
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwaggerGen();
            var initialize = IocAutofacContainer.InitializeContainer(services);
            return new AutofacServiceProvider(initialize);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Oechsle Api v1"));
        }
    }
}
