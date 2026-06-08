using PopDesing.Application.Dtos;
using System.Net;
using System.Text.Json;

namespace PopDesing.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await TratarExceptionAsync(context, ex);
            }
        }

        private static Task TratarExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = ResultadoDto<bool>.RetornaErro($"Um erro inesperado ocorreu. Detalhes: {ex.Message}", ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
