namespace StationeryStore.Data.Entities;

public sealed class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}