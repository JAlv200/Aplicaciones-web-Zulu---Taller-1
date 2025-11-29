using System.Net;
using System.Text.Json;

namespace Taller.Frontend.Repositories;

public class HttpResponseWrapper<T>
{
    public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
    {
        Response = response;
        Error = error;
        HttpResponseMessage = httpResponseMessage;
    }

    public T? Response { get; }
    public bool Error { get; }
    public HttpResponseMessage HttpResponseMessage { get; }

    public async Task<string?> GetErrorMessageAsync()
    {
        if (!Error)
        {
            return null;
        }

        var statusCode = HttpResponseMessage.StatusCode;
        if (statusCode == HttpStatusCode.NotFound)
        {
            return "Recurso no encontrado.";
        }
        if (statusCode == HttpStatusCode.BadRequest)
        {
            var content = await HttpResponseMessage.Content.ReadAsStringAsync();

            try
            {
                // Deserialize JSON Object that ASP.NET Core sends with the error of the data notations
                var errorObj = JsonSerializer.Deserialize<JsonElement>(content);

                // Tryint to extract error
                if (errorObj.TryGetProperty("errors", out var errors))
                {
                    var firstError = errors.EnumerateObject().First();
                    var firstMessage = firstError.Value.EnumerateArray().First().GetString();
                    return firstMessage ?? content;
                }

                // IF its just a string
                return content.Trim('"');
            }
            catch
            {
                return content;
            }
            ;
        }
        if (statusCode == HttpStatusCode.Unauthorized)
        {
            return "Tienes que estar logueado para ejecutar esta operación.";
        }
        if (statusCode == HttpStatusCode.Forbidden)
        {
            return "No tienes permisos para hacer esta operación.";
        }

        return "Ha ocurrido un error inesperado.";
    }
}