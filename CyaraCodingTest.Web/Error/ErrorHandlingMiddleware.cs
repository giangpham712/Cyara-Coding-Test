using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts;
using CyaraCodingTest.Application.Contracts.Dtos;
using CyaraCodingTest.Application.Exceptions;

namespace CyaraCodingTest.Web.Error
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var errorResponse = new ApiErrorResponse();

                switch (error)
                {
                    case EntityNotFoundException:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    case AuthenticationException:
                    case TokenValidationException:
                        response.StatusCode = (int) HttpStatusCode.Unauthorized;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                errorResponse.ErrorMessage ??= error.Message;

                var result = JsonSerializer.Serialize(errorResponse, errorResponse.GetType());
                await response.WriteAsync(result);
            }
        }
    }
}
