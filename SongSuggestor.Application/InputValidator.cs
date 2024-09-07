
namespace SongSuggester.Application
{
    public class InputValidator
    {
        public static string? ValidateGenre(string? genre)
        {
            if (string.IsNullOrEmpty(genre))
                return "Genre must not be empty";
            else
                return null;
        }
    }
}
