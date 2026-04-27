using LeadHunterUI.Models;

namespace LeadHunterUI.Services;

public static class FlawAnalyzer
{
    public static (int score, List<string> flaws) Analyze(PlaceResult place)
    {
        var flaws = new List<string>();
        int score = 0;

        // No website — highest value lead for a web agency
        if (string.IsNullOrEmpty(place.WebsiteUri))
        {
            flaws.Add("NO WEBSITE");
            score += 30;
        }

        // No phone number listed
        if (string.IsNullOrEmpty(place.NationalPhoneNumber) &&
            string.IsNullOrEmpty(place.InternationalPhoneNumber))
        {
            flaws.Add("No phone number");
            score += 15;
        }

        // Low or no rating
        if (place.Rating == null || place.Rating == 0)
        {
            flaws.Add("No rating");
            score += 10;
        }
        else if (place.Rating < 3.5)
        {
            flaws.Add($"Low rating ({place.Rating:F1})");
            score += 10;
        }

        // Few or no reviews
        if (place.UserRatingCount == null || place.UserRatingCount == 0)
        {
            flaws.Add("No reviews");
            score += 15;
        }
        else if (place.UserRatingCount < 10)
        {
            flaws.Add($"Few reviews ({place.UserRatingCount})");
            score += 10;
        }
        else if (place.UserRatingCount < 25)
        {
            flaws.Add($"Low review count ({place.UserRatingCount})");
            score += 5;
        }

        // No business hours listed
        if (place.CurrentOpeningHours == null && place.RegularOpeningHours == null)
        {
            flaws.Add("No hours listed");
            score += 10;
        }

        // No photos
        if (place.Photos == null || place.Photos.Count == 0)
        {
            flaws.Add("No photos");
            score += 10;
        }
        else if (place.Photos.Count < 3)
        {
            flaws.Add($"Few photos ({place.Photos.Count})");
            score += 5;
        }

        // Business not operational
        if (!string.IsNullOrEmpty(place.BusinessStatus) &&
            place.BusinessStatus != "OPERATIONAL")
        {
            flaws.Add($"Status: {place.BusinessStatus}");
            score += 5;
        }

        return (score, flaws);
    }

    public static string GetLeadGrade(int flawScore)
    {
        return flawScore switch
        {
            >= 50 => "🔥 HOT",
            >= 30 => "🟠 WARM",
            >= 15 => "🟡 MILD",
            _ => "🟢 LOW"
        };
    }
}
