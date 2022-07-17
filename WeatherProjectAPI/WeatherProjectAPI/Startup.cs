using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using WeatherProjectAPI.DTO;
using Microsoft.EntityFrameworkCore;
using WeatherProjectAPI.DL;
using WeatherProjectAPI.BL;

namespace WeatherProjectAPI
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

            //TO DO 
            //Add authorization middleware

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" }); });
            services.AddAutoMapper(typeof(DTO_AutoMapping));
            services.AddDbContext<WeatherDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WeatherDB")));
            services.AddScoped(typeof(IUserBL), typeof(UserBL));
            services.AddScoped(typeof(IFavoriteBL), typeof(FavoriteBL));
            services.AddScoped(typeof(IUserDL), typeof(UserDL));
            services.AddScoped(typeof(IFavoriteDL), typeof(FavoriteDL));
            services.AddScoped(typeof(IWeatherBL), typeof(WeatherBL));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader());
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
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });



        }
    }
}
