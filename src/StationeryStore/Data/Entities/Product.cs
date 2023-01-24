namespace Data.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
}