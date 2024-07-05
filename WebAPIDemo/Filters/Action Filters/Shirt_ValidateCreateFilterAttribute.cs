using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.DAL;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Filters
{
    public class Shirt_ValidateCreateFilterAttribute : ActionFilterAttribute
    {
        public ApplicationDBContext dBContext;
        public Shirt_ValidateCreateFilterAttribute(ApplicationDBContext context)
        {
            this.dBContext = context;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt is null.");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
            //if (ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size) != null)
            //{
            //    context.ModelState.AddModelError("Shirt", "Shirt is already present into system.");
            //    var problemDetail = new ValidationProblemDetails(context.ModelState)
            //    {
            //        Status = StatusCodes.Status400BadRequest
            //    };
            //    context.Result = new BadRequestObjectResult(problemDetail);
            //}

            var shirtObj = dBContext.shirts.FirstOrDefault(x => !string.IsNullOrWhiteSpace(shirt.Brand)
                                                            && !string.IsNullOrWhiteSpace(x.Brand)
                                                            && x.Brand.ToLower().Equals(shirt.Brand.ToLower())
                                                            && !string.IsNullOrWhiteSpace(shirt.Gender)
                                                            && !string.IsNullOrWhiteSpace(x.Gender)
                                                            && x.Gender.ToLower().Equals(shirt.Gender.ToLower())
                                                            && !string.IsNullOrWhiteSpace(shirt.Color)
                                                            && !string.IsNullOrWhiteSpace(x.Color)
                                                            && x.Color.ToLower().Equals(shirt.Color.ToLower())
                                                            && shirt.Size.HasValue
                                                            && x.Size.HasValue
                                                            && shirt.Size.Value == x.Size.Value);

            if (shirtObj != null)
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
