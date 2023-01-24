namespace StationeryStore.Data.Entities;

public sealed class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string Title { get; set; }
    
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}