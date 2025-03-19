using BookPub.Filters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.ActionFilters
{
    /// <include file='Documentation\Filters\ActionFilters\ValidateId_FilterAttribute.xml' path='doc/validateid/member[@name="T:BookPub.Filters.ActionFilters.ValidateId_FilterAttribute"]' />
    public class ValidateId_FilterAttribute : BaseFilterAttribute
    {
        /// <include file='Documentation\Filters\ActionFilters\ValidateId_FilterAttribute.xml' path='doc/validateid/member[@name="C:BookPub.Filters.ActionFilters.ValidateId_FilterAttribute"]' />
        public ValidateId_FilterAttribute(RepoKey rkey) : base(rkey) { }

        /// <include file='Documentation\Filters\ActionFilters\ValidateId_FilterAttribute.xml' path='doc/validateid/member[@name="M:BookPub.Filters.ActionFilters.ValidateId_FilterAttribute.OnActionExecuting"]' />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            if (id.HasValue)
            {
                if (id.Value < 0)
                {
                    context.ModelState.AddModelError($"{id}", $"{RepositoryHandler.RKey} is invalid!");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!RepositoryHandler.Repository().Exists(id.Value).Result)
                {
                    context.ModelState.AddModelError($"{id}", $"{RepositoryHandler.RKey} does not exist");
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