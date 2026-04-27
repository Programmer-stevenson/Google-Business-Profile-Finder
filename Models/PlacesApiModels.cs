using System.Text.Json.Serialization;

namespace LeadHunterUI.Models;

// Google Places API (New) - Text Search response
public class PlacesSearchResponse
{
    [JsonPropertyName("places")]
    public List<PlaceResult>? Places { get; set; }

    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; }
}

public class PlaceResult
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("displayName")]
    public DisplayName? DisplayName { get; set; }

    [JsonPropertyName("formattedAddress")]
    public string? FormattedAddress { get; set; }

    [JsonPropertyName("nationalPhoneNumber")]
    public string? NationalPhoneNumber { get; set; }

    [JsonPropertyName("internationalPhoneNumber")]
    public string? InternationalPhoneNumber { get; set; }

    [JsonPropertyName("websiteUri")]
    public string? WebsiteUri { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("userRatingCount")]
    public int? UserRatingCount { get; set; }

    [JsonPropertyName("businessStatus")]
    public string? BusinessStatus { get; set; }

    [JsonPropertyName("googleMapsUri")]
    public string? GoogleMapsUri { get; set; }

    [JsonPropertyName("currentOpeningHours")]
    public OpeningHours? CurrentOpeningHours { get; set; }

    [JsonPropertyName("regularOpeningHours")]
    public OpeningHours? RegularOpeningHours { get; set; }

    [JsonPropertyName("photos")]
    public List<PlacePhoto>? Photos { get; set; }
}

public class DisplayName
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("languageCode")]
    public string? LanguageCode { get; set; }
}

public class OpeningHours
{
    [JsonPropertyName("weekdayDescriptions")]
    public List<string>? WeekdayDescriptions { get; set; }
}

public class PlacePhoto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
