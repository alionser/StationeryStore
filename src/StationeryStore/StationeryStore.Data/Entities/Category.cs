namespace StationeryStore.Data.Entities;

public sealed class Category
{
    public int CategoryId { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}