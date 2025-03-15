using BookPub.Filters.ActionFilters.BaseFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BookPubDB.Model;

namespace BookPub.Filters.ActionFilters
{
    public class ValidateCreate_FilterAttribute(string name) : BaseFilterAttribute(name)
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var item = context.ActionArguments["item"];

            if (item == null)
            {
                context.ModelState.AddModelError($"{Name}", $"{Name} object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
