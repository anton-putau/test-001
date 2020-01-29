using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WingsOn.Common.Exceptions;

namespace WingsOn.Api.Infrastructure
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        private static readonly Dictionary<Type, HttpStatusCode> _exceptionToCodeMap = new Dictionary<Type, HttpStatusCode>
        {
            { typeof(NotFoundException), HttpStatusCode.NotFound }
        };

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var exceptionType = ex.GetType();

            var result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)_exceptionToCodeMap.GetValueOrDefault(exceptionType, HttpStatusCode.InternalServerError);

            return context.Response.WriteAsync(result);
        }
    }
}
