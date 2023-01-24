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
        app.UseEndpoints(builder =>
        {
            builder.MapRazorPages();
        });
    }
}