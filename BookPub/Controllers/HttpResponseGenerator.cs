
using BookPubDB.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/member[@name="T:BookPub.Controllers.HttpResponseGenerator`1"]' />
    public class HttpResponseGenerator<TType> : ControllerBase where TType : class
    {
        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/member[@name="C:BookPub.Controllers.HttpResponseGenerator`1"]/summary' />
        public HttpResponseGenerator() { }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.Created"]' />
        public IActionResult Created(TType? result)
        {
            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Created);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
        }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.Deleted"]' />
        public IActionResult Deleted(TType? result)
        {
            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Deleted);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
        }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.Ok(System.Collections.Generic.List{TType})"]' />
        public IActionResult Ok(TType? result)
        {
            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Ok);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.NotFound);
            }
        }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.Ok(TType)"]' />
        public IActionResult Ok(List<TType> result)
        {
            if (result != null && result.Count > 0)
            {
                return GetIActionResult(result, ActionResultStatus.Ok);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
        }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.Update"]' />
        public IActionResult Update(TType? result)
        {
            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Updated);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
        }

        /// <include file='Documentation/Controllers/HttpResponseGenerator.xml' path='doc/httpresponsegenerator/methods/member[@name="M:BookPub.Controllers.HttpResponseGenerator`1.GetIActionResult"]' />
        private IActionResult GetIActionResult(object? type, ActionResultStatus ars)
        {
            switch (ars)
            {
                case ActionResultStatus.Created:
                    return Created("", type);

                case ActionResultStatus.Deleted:
                    return StatusCode((int)ActionResultStatus.Deleted, new { message = "Deleted", type });

                case ActionResultStatus.Updated:
                    return StatusCode((int)ActionResultStatus.Updated, new { message = "Updated", type });

                case ActionResultStatus.Ok:
                    return Ok(type);

                case ActionResultStatus.NotFound:
                    return NotFound("Get request failed");

                default:
                    return NotFound($"Invalid Operation");
            }
        }
    }
}