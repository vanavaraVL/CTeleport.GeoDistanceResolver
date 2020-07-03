using System;
using System.Threading.Tasks;
using CTeleport.GeoDistanceResolver.Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CTeleport.GeoDistanceResolver.Web.Middleware
{
    /// <summary>
    /// Middleware to catch and work with exceptions
    /// </summary>
    public class ApplicationExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly ILogger<ApplicationExceptionHandler> _logger;

        public ApplicationExceptionHandler(RequestDelegate next, ILogger<ApplicationExceptionHandler> logger)
        {
            _next = next;

            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("swagger"))
            {
                await _next.Invoke(context);
            }
            else
            {
                try
                {
                    await _next(context);
                }
                catch (ValidationException ex)
                {
                    await ValidationRequest(
                        context,
                        SerializeToJson(new { message = ex.Message }), ex);
                }
                catch (SerializationException ex)
                {
                    await BadRequest(
                        context,
                        SerializeToJson(new { message = ex.Message }), ex);
                }
                catch (GatewayException ex)
                {
                    await BadRequest(
                        context,
                        SerializeToJson(new { message = ex.Message }), ex);
                }
                catch (FriendlyException ex)
                {
                    await BadRequest(
                        context,
                        SerializeToJson(new { message = ex.Message }), ex);
                }
                catch (Exception ex)
                {
                    await UnhandledRequest(
                        context,
                        SerializeToJson(new { message = "Ooops...something went wrong" }), ex);
                }
            }
        }

        private string SerializeToJson(object messageObject) =>
            JsonConvert.SerializeObject(messageObject, _jsonSettings);

        private async Task BadRequest(HttpContext context, string errorInfo, Exception ex)
        {
            _logger.LogError(ex.StackTrace);

            await StatusCode(
                StatusCodes.Status400BadRequest,
                context,
                errorInfo
            );
        }

        private async Task ValidationRequest(HttpContext context, string errorInfo, Exception ex)
        {
            _logger.LogError(ex.StackTrace);

            await StatusCode(
                StatusCodes.Status404NotFound,
                context,
                errorInfo
            );
        }


        private async Task UnhandledRequest(HttpContext context, string errorInfo, Exception ex)
        {
            _logger.LogError(ex.StackTrace);

            await StatusCode(
                StatusCodes.Status500InternalServerError,
                context,
                errorInfo
            );
        }

        private static async Task StatusCode(int statusCode, HttpContext context, string errorInfo)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(errorInfo);
        }
    }
}
