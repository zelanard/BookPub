using BookPub.Filters.ActionFilters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.ExceptionFilters
{
    public class Update_ExceptionFilterAttribute(string name) : BaseExceptionFilterAttribute(name)
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if(int.TryParse(context.RouteData.Values["id"] as string, out int id))
            {
                if (!Repo[Name].Exists(id).Result)
                {
                    context.ModelState.AddModelError($"{id}", $"{Name} with id: {id} no longer exists");
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