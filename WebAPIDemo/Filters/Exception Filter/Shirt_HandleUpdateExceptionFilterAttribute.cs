using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.DAL;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters.Exception_Filter
{
    public class Shirt_HandleUpdateExceptionFilterAttribute : ExceptionFilterAttribute
    {
        ApplicationDBContext dbContext;
        public Shirt_HandleUpdateExceptionFilterAttribute(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var id = context.RouteData.Values["id"] as string;

            if (int.TryParse(id, out int shirtID))
            {
                if (dbContext.shirts.FirstOrDefault(x=>x.ShirtId == shirtID) == null)
                {
                    context.ModelState.AddModelError("ShirtID", "Shirt doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
                //if (!ShirtRepository.ShirtExists(shirtID))
                //{
                //    context.ModelState.AddModelError("ShirtID", "Shirt doesn't exist anymore.");
                //    var problemDetails = new ValidationProblemDetails(context.ModelState)
                //    {
                //        Status = StatusCodes.Status404NotFound
                //    };
                //    context.Result = new NotFoundObjectResult(problemDetails);
                //}
            }
        }
    }
}
