namespace _Project_CheatSheet.Common.Filters_and_Attributes.Filters;

using System.Text;

using _Project_CheatSheet.Common.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionHandlingActionFilter : ExceptionFilterAttribute
{
    private const int DefaultFailureStatusCode = 400;
    private readonly int statusCode;

    public ExceptionHandlingActionFilter(int statusCode = DefaultFailureStatusCode)
    {
        this.statusCode = statusCode;
    }

    public override async Task OnExceptionAsync(ExceptionContext context)
    {
        var message = context.Exception is CustomException 
            ? context.Exception.Message 
            : "There was an error";

        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = statusCode;
        context.HttpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(message);

        await context.HttpContext.Response.WriteAsync(message, Encoding.UTF8);

    }
}