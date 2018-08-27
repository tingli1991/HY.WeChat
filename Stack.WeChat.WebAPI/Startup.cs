using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stack.WeChat.Utils.Autofac;
using Stack.WeChat.WebAPI.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Stack.WeChat.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromSeconds(7200);
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "Version 1.0",
                    Description = "Jesse作者",
                    Title = "微信的API文档"
                });

                var basePath = AppContext.BaseDirectory;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                var xmlPath = Path.Combine(basePath, commentsFileName);
                options.IncludeXmlComments(xmlPath);
                options.OperationFilter<AssignOperationVendorExtensions>();
            });

            services.AddDistributedMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            return AutofacService.RegisterAutofac(services, "Stack.WeChat.Contracts", "Stack.WeChat.Service");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stack.WeChat.WebAPI");
                    c.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseSession();
            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}