using SongSuggester.Infrastructure.Exceptions;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SongSuggester.Infrastructure.Requests.Songs
{
    public class SongWebRequest
    {
        private const string _token = "c21kYjo6ZWYzZWMwZjRiZDcwNDE4ZDllYjlmMDE3MWI0ODcwZDZ4";
        private const string _baseUrl = "https://smdb.azurewebsites.net/api/songs";


        public async Task<IList<SongModel>?> GetSongsByGenre(string genre)
        {
            string paramUrl = $"{_baseUrl}?genre={genre}";

            using (var client = new HttpClient())
            {
                // Set the Bearer token in the Authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                // Send the request
                HttpResponseMessage response = await client.GetAsync(paramUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<SongModel>>(responseData, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    throw new DataResponseException(response);
                }
            }
        }
    }
}
