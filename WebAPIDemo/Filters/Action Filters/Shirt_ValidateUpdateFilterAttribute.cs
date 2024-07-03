using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters
{
    public class Shirt_ValidateUpdateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if(id.HasValue && shirt != null && id!= shirt.ShirtId)
            {
                context.ModelState.AddModelError("ShirtId", "ShirtId is not same.");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
        }
    }
}
