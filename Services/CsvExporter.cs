using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LeadHunterUI.Models;

namespace LeadHunterUI.Services;

public static class CsvExporter
{
    public static void Export(List<BusinessLead> leads, string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, config);

        csv.WriteHeader<LeadExportRow>();
        csv.NextRecord();

        foreach (var lead in leads.OrderByDescending(l => l.FlawScore))
        {
            csv.WriteRecord(new LeadExportRow
            {
                Name = lead.Name,
                Address = lead.Address,
                Phone = lead.Phone ?? "N/A",
                Website = lead.Website ?? "NONE",
                Rating = lead.Rating?.ToString("F1") ?? "N/A",
                Reviews = lead.ReviewCount?.ToString() ?? "0",
                Industry = lead.Industry,
                City = lead.City,
                FlawScore = lead.FlawScore,
                LeadGrade = FlawAnalyzer.GetLeadGrade(lead.FlawScore),
                Flaws = lead.Flaws,
                GoogleMaps = lead.GoogleMapsUrl ?? "",
                Contacted = lead.Contacted ? "Yes" : "No",
                Notes = lead.Notes ?? ""
            });
            csv.NextRecord();
        }
    }
}

public class LeadExportRow
{
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Website { get; set; } = "";
    public string Rating { get; set; } = "";
    public string Reviews { get; set; } = "";
    public string Industry { get; set; } = "";
    public string City { get; set; } = "";
    public int FlawScore { get; set; }
    public string LeadGrade { get; set; } = "";
    public string Flaws { get; set; } = "";
    public string GoogleMaps { get; set; } = "";
    public string Contacted { get; set; } = "";
    public string Notes { get; set; } = "";
}
