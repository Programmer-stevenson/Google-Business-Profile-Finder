using System.ComponentModel.DataAnnotations;

namespace LeadHunterUI.Models;

public class SearchHistory
{
    [Key]
    public int Id { get; set; }
    public string Industry { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int ResultsFound { get; set; }
    public int ResultsMatched { get; set; }
    public int NewLeadsSaved { get; set; }
    public string FiltersUsed { get; set; } = string.Empty;
    public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
}
