using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters.Exception_Filter
{
    public class Shirt_HandleUpdateExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var id = context.RouteData.Values["id"] as string;

            if(int.TryParse(id,out int shirtID))
            {
                if (!ShirtRepository.ShirtExists(shirtID))
                {
                    context.ModelState.AddModelError("ShirtID", "Shirt doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
