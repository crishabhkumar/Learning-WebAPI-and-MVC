using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters
{
    public class Shirt_ValidateCreateFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;

            if(shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt is null.");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
            if(ShirtRepository.GetShirtByProperties(shirt.Brand,shirt.Gender,shirt.Color,shirt.Size) != null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt is already present into system.");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
        }
    }
}
