
namespace Domain.Entities;
public class Quote
{
    public int id { get; set; }
    public int Categoryid { get; set; }

    public string? Author { get; set; }
    public string? QuoteText { get; set; }
}

