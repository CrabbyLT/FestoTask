using FestoFilmaiAPI.Repository;
using FestoFilmaiAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FestoFilmaiAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FestoFilmaiAPI", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSingleton<IApiReaderService, ApiReaderService>(_ => new ApiReaderService(new System.Net.Http.HttpClient()));
            services.AddSingleton<IMovieSearchRepository, MovieSearchRepository>(_ => new MovieSearchRepository("MovieSearchRepo.json"));
            services.AddSingleton<IMovieDetailRepository, MovieDetailRepository>(_ => new MovieDetailRepository("MovieDetailRepo.json"));
            services.AddSingleton<IMoviesService, MoviesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FestoFilmaiAPI v1"));
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
