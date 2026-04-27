using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using LeadHunterUI.Models;

namespace LeadHunterUI.Services;

public class GooglePlacesService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;
    private const string BaseUrl = "https://places.googleapis.com/v1/places:searchText";

    public GooglePlacesService(string apiKey)
    {
        _apiKey = apiKey;
        _http = new HttpClient();
    }

    public async Task<List<PlaceResult>> SearchBusinessesAsync(string industry, string city, int maxResults = 20)
    {
        var allResults = new List<PlaceResult>();
        string? pageToken = null;
        int fetched = 0;

        do
        {
            var requestBody = new Dictionary<string, object>
            {
                { "textQuery", $"{industry} in {city}" },
                { "languageCode", "en" }
            };

            if (pageToken != null)
                requestBody["pageToken"] = pageToken;

            var json = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Required headers for Places API (New)
            request.Headers.Add("X-Goog-Api-Key", _apiKey);
            request.Headers.Add("X-Goog-FieldMask",
                "places.id,places.displayName,places.formattedAddress," +
                "places.nationalPhoneNumber,places.internationalPhoneNumber," +
                "places.websiteUri,places.rating,places.userRatingCount," +
                "places.businessStatus,places.googleMapsUri," +
                "places.currentOpeningHours,places.regularOpeningHours,places.photos," +
                "nextPageToken");

            var response = await _http.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  API Error ({response.StatusCode}): {content}");
                Console.ResetColor();
                break;
            }

            var result = JsonSerializer.Deserialize<PlacesSearchResponse>(content);

            if (result?.Places != null)
            {
                allResults.AddRange(result.Places);
                fetched += result.Places.Count;
            }

            pageToken = result?.NextPageToken;

            // Respect rate limits
            if (pageToken != null)
                await Task.Delay(500);

        } while (pageToken != null && fetched < maxResults);

        return allResults.Take(maxResults).ToList();
    }
}
