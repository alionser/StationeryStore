namespace StationeryStore.Data.Entities;

public sealed class Tag
{
    public int TagId { get; set; }

    public string Title { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}