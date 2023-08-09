namespace _Project_CheatSheet.Common.Filters
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Text;

    public class ActionHandlingFilter : Attribute, IAsyncResultFilter
    {
        private const int DefaultFailureStatusCode = 400;
        private readonly string failureMessage;
        private readonly int failureStatusCode;

        private readonly string successMessage;

        public ActionHandlingFilter(
            string successMessage = "",
            string failureMessage = "",
            int failureStatusCode = DefaultFailureStatusCode)
        {
            this.successMessage = successMessage;
            this.failureMessage = failureMessage;
            this.failureStatusCode = failureStatusCode;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            var objectResult = context.Result as ObjectResult;
            if (objectResult?.Value == null)
            {
                context.HttpContext.Response.StatusCode = failureStatusCode;
                context.HttpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(failureMessage);
                await context.HttpContext.Response.WriteAsync(failureMessage, Encoding.UTF8);
            }
            else if (string.IsNullOrWhiteSpace(successMessage))
            {
                context.Result = new OkObjectResult(context);
            }
            else
            {
                context.Result = new OkObjectResult(successMessage);
            }
        }
    }
}