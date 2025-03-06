using BookPub.Filters.ActionFilters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace BookPub.Filters.ActionFilters
{
    public class ValidateUpdate_FilterAttribute(string name) : BaseFilterAttribute(name)
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var item = context.ActionArguments["item"] as JObject;
            var success = int.TryParse(item!["id"]!.ToString(), out int itemId);

            if (!id.HasValue)
            {
                context.ModelState.AddModelError($"{Name}", "No id provided");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (!success)
            {
                context.ModelState.AddModelError($"{Name}", $"No {Name} object provided");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (id != itemId)
            {
                context.ModelState.AddModelError($"{id}", $"The id of the provided {Name}: {itemId} is not the same as the provided id: {id}");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
