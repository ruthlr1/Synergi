
namespace SongSuggester.Application.Services.Songs
{
    public interface ISongService
    {
        public Task<List<string>> GetSongs(string genreName);
    }
}
