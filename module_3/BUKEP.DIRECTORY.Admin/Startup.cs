using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BUKEP.DIRECTORY.Admin
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DirectoryDbContext>(option => option.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<IDbRepository<DataSourceAttributeValueEntity>, EfRepository<DirectoryDbContext, DataSourceAttributeValueEntity>>();
            services.AddScoped<IDbRepository<DataSourceAttribteEntity>, EfRepository<DirectoryDbContext, DataSourceAttribteEntity>>();
            services.AddScoped<IDbRepository<FieldAttributeValueEntity>, EfRepository<DirectoryDbContext, FieldAttributeValueEntity>>();
            services.AddScoped<IDbRepository<FieldAttributeEntity>, EfRepository<DirectoryDbContext, FieldAttributeEntity>>();
            services.AddScoped<IDbRepository<DataProviderEntity>, EfRepository<DirectoryDbContext, DataProviderEntity>>();
            services.AddScoped<IDbRepository<DataSourceEntity>, EfRepository<DirectoryDbContext, DataSourceEntity>>();
            services.AddScoped<IDbRepository<AttributeEntity>, EfRepository<DirectoryDbContext, AttributeEntity>>();
            services.AddScoped<IDbRepository<FieldEntity>, EfRepository<DirectoryDbContext, FieldEntity>>();

            // Register services
            services.AddScoped<IDataProviderService, DataProviderService>();
            services.AddScoped<IDataSourceService, DataSourceService>();
            services.AddScoped<IAttributeService, AttributeService>();
            services.AddScoped<IFieldService, FieldService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
