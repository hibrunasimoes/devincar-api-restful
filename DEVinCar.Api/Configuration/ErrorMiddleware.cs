using System;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using System.Net;

namespace DEVinCar.Api.Configuration
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await TratamentoExcecao(context, ex);
            }
        }

        private Task TratamentoExcecao(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            if (ex is IsExistsException)
            {
                status = HttpStatusCode.NotFound;
                message = ex.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = "An error has occurred, please contact TI!";
            }

            var response = new ErrorDTO(message);

            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}

