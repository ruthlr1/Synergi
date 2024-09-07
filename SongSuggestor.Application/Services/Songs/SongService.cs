using SongSuggester.Application.Services.Logs;
using SongSuggester.Infrastructure.Exceptions;
using SongSuggester.Infrastructure.Requests.Songs;

namespace SongSuggester.Application.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly ILoggerService _loggerService;
        public SongService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }


        public async Task<List<string>> GetSongs(string genreName)
        {
            List<string> display = new List<string>();
            try
            {
                SongWebRequest request = new SongWebRequest();
                var songModels =  await request.GetSongsByGenre(genreName);
                if(songModels == null || !songModels.Any())
                    display.Add("No songs found");
                else
                {
                    display.Add($"We have found {songModels.Count} songs for you;");
                    foreach (var song in songModels.OrderBy(x => x.ArtistName).ThenBy(x => x.Name))
                    {
                        display.Add($"{song.Name} by {song.ArtistName}");
                    }
                }
            }
            catch (DataResponseException ex)
            {
                _loggerService.LogError(ex);
                display.Add("Unable to retrieve songs from server. Check log for details");
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex);
                display.Add("Something went wrong. Check log for details");
            }

            return display;
        }
    }
}
