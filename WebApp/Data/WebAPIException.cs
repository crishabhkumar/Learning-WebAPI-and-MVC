using System.Text.Json;

namespace WebApp.Data
{
    public class WebAPIException : Exception
    {
        public ErrorResponse? ErrorResponse { get; }

        public WebAPIException(string errorJSon)
        {
            ErrorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorJSon);
        }
    }
}
