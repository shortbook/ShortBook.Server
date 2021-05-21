using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShortBook.Server.Exceptions;

namespace ShortBook.Server
{
    /// <summary>
    /// 异常捕获中间件
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 获取异常捕获中间件新实例
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (exception is ShortBookServerNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is ShortBookServerForbiddenException) code = HttpStatusCode.Forbidden;
            else if (exception is ShortBookServerUnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is ShortBookServerException) code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new {error = exception.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }
    }
}