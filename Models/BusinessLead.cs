using System.ComponentModel.DataAnnotations;

namespace LeadHunterUI.Models;

public class BusinessLead
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public double? Rating { get; set; }
    public int? ReviewCount { get; set; }
    public string? BusinessStatus { get; set; }
    public string? PlaceId { get; set; }
    public string? GoogleMapsUrl { get; set; }
    public string Industry { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int FlawScore { get; set; }
    public string Flaws { get; set; } = string.Empty;
    public DateTime ScrapedAt { get; set; } = DateTime.UtcNow;
    public bool Contacted { get; set; } = false;
    public string? Notes { get; set; }
}
