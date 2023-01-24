namespace Data.Entities;

public sealed class Review
{
    public int ReviewId { get; set; }

    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    
    public int BookId { get; set; }
}