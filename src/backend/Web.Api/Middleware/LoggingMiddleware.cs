using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NLog;

namespace Web.Api.Middleware;

internal sealed class LoggingMiddleware(RequestDelegate next)
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public async Task Invoke(HttpContext httpContext)
    {
        var request = httpContext.Request;

        var requestPath = $"{request.Path}{request.QueryString}";

        try
        {
            var log = _logger;
            if (request.ContentLength > 0)
            {
                log = log.WithProperty("RequestBody", await GetRequestBody(request));
            }
            log.Info("[{traceId}] {method}: {path}",
                httpContext.TraceIdentifier,
                request.Method,
                requestPath);
        }
        catch (Exception ex)
        {
            _logger.Info("[{traceId}] Failed to parse request body: {Message}\n{Trace}",
                httpContext.TraceIdentifier,
                ex.Message,
                ex.StackTrace);
        }
        finally
        {
            await next.Invoke(httpContext);;
        }
    }
    
    private async Task<string> GetRequestBody(HttpRequest request)
    {
        if (request.ContentType?.Contains("multipart", StringComparison.OrdinalIgnoreCase) is true)
        {
            return GetDataFromForm(request.Form);
        }

        request.EnableBuffering();
        request.Body.Seek(0, SeekOrigin.Begin);

        string body;
        using (var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true))
        {
            body = await reader.ReadToEndAsync();
        }

        request.Body.Seek(0, SeekOrigin.Begin);

        return body;
    }
    
    private string GetDataFromForm(IFormCollection form) => JsonSerializer.Serialize(form);
}