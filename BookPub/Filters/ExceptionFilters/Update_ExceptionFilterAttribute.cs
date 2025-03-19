using BookPub.Filters.BaseFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.ExceptionFilters
{
    /// <include file='Documentation\Filters\ExceptionFilters\Update_ExceptionFilterAttribute.xml' path='doc/updateexception/member[@name="T:BookPub.Filters.ExceptionFilters.Update_ExceptionFilterAttribute"]' />
    public class Update_ExceptionFilterAttribute : BaseExceptionFilterAttribute
    {
        /// <include file='Documentation\Filters\ExceptionFilters\Update_ExceptionFilterAttribute.xml' path='doc/updateexception/member[@name="C:BookPub.Filters.ExceptionFilters.Update_ExceptionFilterAttribute"]' />
        public Update_ExceptionFilterAttribute(RepoKey rkey) : base(rkey) { }

        /// <include file='Documentation\Filters\ExceptionFilters\Update_ExceptionFilterAttribute.xml' path='doc/updateexception/member[@name="M:BookPub.Filters.ExceptionFilters.Update_ExceptionFilterAttribute.OnException"]' />
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (int.TryParse(context.RouteData.Values["id"] as string, out int id))
            {
                if (!RepositoryHandler.Repository().Exists(id).Result)
                {
                    context.ModelState.AddModelError($"{id}", $"{RepositoryHandler.RKey} with id: {id} no longer exists");
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