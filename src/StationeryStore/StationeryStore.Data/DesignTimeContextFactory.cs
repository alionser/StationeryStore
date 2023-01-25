using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StationeryStore.Data;

public class DesignTimeContextFactory: IDesignTimeDbContextFactory<DataContext>
{
    private const string connectionString =              
        "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=StationeryStore;Pooling=true;";

    public DataContext CreateDbContext(string[] args)  
    {
        var optionsBuilder =                              
            new DbContextOptionsBuilder<DataContext>(); 
        optionsBuilder.UseNpgsql(connectionString);    

        return new DataContext(optionsBuilder.Options); 
    }
}