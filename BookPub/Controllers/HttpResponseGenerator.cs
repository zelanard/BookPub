
using BookPubDB.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>HttpResponseGenerator</c> Provides methods which generate <see cref="IActionResult"/>s
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public class HttpResponseGenerator<TType> : ControllerBase where TType : class
    {
        /// <summary>
        /// Handles Created <see cref="IActionResult"/>s
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Created if result is not empty else BadRequest</returns>
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

        /// <summary>
        /// Handles Deleted <see cref="IActionResult"/>s
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Deleted if result is not empty else BadRequest</returns>
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

        /// <summary>
        /// Handles Ok <see cref="IActionResult"/>s with a single <see cref="TType"/>
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Ok if result is not empty else NotFound</returns>
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

        /// <summary>
        /// Handles Ok <see cref="IActionResult"/>s with a List of <see cref="TType"/>
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Created if result is not empty else NotFound</returns>
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

        /// <summary>
        /// Handles Updated <see cref="IActionResult"/>s
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Updated if result is not empty else BadRequest</returns>
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

        /// <summary>
        /// Generates an appropriate <see cref="IActionResult"/> based on the incomming ActionResultStatus
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ars"></param>
        /// <returns>An IActionResult</returns>
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