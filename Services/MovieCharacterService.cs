using SwipeCardViewDemo.Helpers;
using SwipeCardViewDemo.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SwipeCardViewDemo.Services
{
    public class MovieCharacterService : IMovieCharacterService
    {
        HttpClient _httpClient;
        public List<MovieCharacter> MovieCharacterList { get; private set; }

        public MovieCharacterService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<MovieCharacter>> GetMovieCharacterDataAsync()
        {
            MovieCharacterList = new List<MovieCharacter>();
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MovieCharacterList = JsonSerializer.Deserialize<List<MovieCharacter>>(content);
                }
                else
                {
                    Debug.WriteLine($"ERROR: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR : ", ex.Message);
            }

            return MovieCharacterList;
        }
    }
}
