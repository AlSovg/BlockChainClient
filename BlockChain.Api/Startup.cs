using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using BlockChain.Api.Repositories;
using BlockChain.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BlockChain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "blockchain v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        [UnconditionalSuppressMessage("Trimming",
            "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code",
            Justification = "<Pending>")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend_sharp", Version = "v1" });
            });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.TypeInfoResolverChain.Clear();
                    options.JsonSerializerOptions.TypeInfoResolverChain.Add(new DefaultJsonTypeInfoResolver());
                });

            services.AddTransient<UpdateRepository>();
            services.AddHttpClient<UpdateRepository>();

            services.AddTransient<DbContext, ApplicationContext>();

            var provider = Configuration.GetValue("Provider", "Postgres");
            if (provider == "Postgres")
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            }
            // else if (provider == "SqlServer")
            // {
            //     services.AddDbContext<ApplicationContext>(options =>
            //         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // }
            else
            {
                throw new InvalidOperationException(
                    "Invalid provider. Supported providers are 'Postgres' and 'SqlServer'.");
            }
        }
    }
}