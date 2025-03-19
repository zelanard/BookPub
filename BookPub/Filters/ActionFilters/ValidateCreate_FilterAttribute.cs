using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BookPub.Filters.BaseFilters;
using Utils;

namespace BookPub.Filters.ActionFilters
{
    /// <include file='Documentation\Filters\ActionFilters\ValidateCreate_FilterAttribute.xml' path='doc/validatecreate/member[@name="T:BookPub.Filters.ActionFilters.ValidateCreate_FilterAttribute"]' />
    public class ValidateCreate_FilterAttribute : BaseFilterAttribute
    {
        /// <include file='Documentation\Filters\ActionFilters\ValidateCreate_FilterAttribute.xml' path='doc/validatecreate/member[@name="C:BookPub.Filters.ActionFilters.ValidateCreate_FilterAttribute"]' />
        public ValidateCreate_FilterAttribute(RepoKey rkey) : base(rkey) { }

        /// <include file='Documentation\Filters\ActionFilters\ValidateCreate_FilterAttribute.xml' path='doc/validatecreate/member[@name="M:BookPub.Filters.ActionFilters.ValidateCreate_FilterAttribute.OnActionExecuting"]' />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var item = context.ActionArguments["item"];

            if (item == null || !item.HasProperties())
            {
                context.ModelState.AddModelError($"{RepositoryHandler.RKey}", $"{RepositoryHandler.RKey} object is null or empty");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
