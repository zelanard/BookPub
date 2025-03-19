using BookPub.Filters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace BookPub.Filters.ActionFilters
{
    /// <include file='Documentation\Filters\ActionFilters\ValidateUpdate_FilterAttribute.xml' path='doc/validateupdate/member[@name="T:BookPub.Filters.ActionFilters.ValidateUpdate_FilterAttribute"]' />
    public class ValidateUpdate_FilterAttribute : BaseFilterAttribute
    {
        /// <include file='Documentation\Filters\ActionFilters\ValidateUpdate_FilterAttribute.xml' path='doc/validateupdate/member[@name="C:BookPub.Filters.ActionFilters.ValidateUpdate_FilterAttribute"]' />
        public ValidateUpdate_FilterAttribute(RepoKey rkey) : base(rkey) { }

        /// <include file='Documentation\Filters\ActionFilters\ValidateUpdate_FilterAttribute.xml' path='doc/validateupdate/member[@name="M:BookPub.Filters.ActionFilters.ValidateUpdate_FilterAttribute.OnActionExecuting"]' />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var item = context.ActionArguments["item"] as JObject;
            var success = int.TryParse(item!["id"]!.ToString(), out int itemId);

            if (!id.HasValue)
            {
                context.ModelState.AddModelError($"{RepositoryHandler.RKey}", "No id provided");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (!success)
            {
                context.ModelState.AddModelError($"{RepositoryHandler.RKey}", $"No {RepositoryHandler.RKey} object provided");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (id != itemId)
            {
                context.ModelState.AddModelError($"{id}", $"The id of the provided {RepositoryHandler.RKey}: {itemId} is not the same as the provided id: {id}");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
