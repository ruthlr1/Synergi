using System.Text;

namespace SongSuggester.Infrastructure.Exceptions
{
    public class DataResponseException : Exception
    {
        public DataResponseException(HttpResponseMessage responseMessage) : base(ToMessage(responseMessage))
        {

        }

        private static string ToMessage(HttpResponseMessage responseMessage)
        {
            StringBuilder sb = new StringBuilder();

            if (!responseMessage.IsSuccessStatusCode)
            {
                sb.AppendLine($"Response returned status: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}");

                if (responseMessage.RequestMessage != null)
                    sb.AppendLine($"URI : {responseMessage.RequestMessage.RequestUri}");
            }

            return sb.ToString();
        }
    }
}
