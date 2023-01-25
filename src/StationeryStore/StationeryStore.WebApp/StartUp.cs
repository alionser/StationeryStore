using Autofac;
using Microsoft.EntityFrameworkCore;
using StationeryStore.Data;

namespace StationeryStore.WebApp;

public sealed class StartUp
{
    public IConfiguration Configuration;

    public StartUp(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        
        
        services.AddDbContext<DataContext>(
            options =>
            {
                options.UseNpgsql(connectionString, b =>
                {
                    b.MigrationsAssembly("StationeryStore.Data");
                });
            },
            ServiceLifetime.Transient);

        // services.AddDbContext<DataContext>(options => { options.UseNpgsql(connectionString); },
        // ServiceLifetime.Transient);
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType(typeof(DataContext))
            .As<DataContext>()
            .InstancePerLifetimeScope();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseEndpoints(builder => { builder.MapRazorPages(); });
        
        var dataContext = app.ApplicationServices.GetRequiredService<DataContext>();
        dataContext.Database.Migrate();
    }
}