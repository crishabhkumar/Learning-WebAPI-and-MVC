using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.DAL;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters
{
    public class Shirt_ValidShirtIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDBContext dBContext;
        public Shirt_ValidShirtIdFilterAttribute(ApplicationDBContext db)
        {
            this.dBContext = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid.");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetail);
                }
                //else if (!ShirtRepository.ShirtExists(shirtId.Value))
                else
                {
                    var shirt = dBContext.shirts.Find(shirtId.Value);
                    if (shirt == null)
                    {
                        context.ModelState.AddModelError("ShirtId", "ShirtId doesn't exist.");
                        var problemDetail = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetail);
                    }
                    else
                    {
                        context.HttpContext.Items["shirt"] = shirt;
                    }
                }
            }

        }
    }
}
