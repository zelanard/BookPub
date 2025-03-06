using BookPub.Filters.ActionFilters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.ActionFilters
{
    /// <summary>
    /// <c>Artist_Id_FilterAttribute</c> validates incomming ID's.
    /// </summary>
    /// <remarks>
    /// Inherits:<br/>
    /// * <see cref="BaseFilterAttribute"/><br/>
    /// * <see cref="ActionFilterAttribute"/>
    /// </remarks>
    public class ValidateId_FilterAttribute(string name) : BaseFilterAttribute(name)
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            if (id.HasValue)
            {
                if (id.Value < 0)
                {
                    context.ModelState.AddModelError($"{id}", $"{Name} is invalid!");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!Repo[Name].Exists(id.Value).Result)
                {
                    context.ModelState.AddModelError($"{id}", $"{Name} does not exist");
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