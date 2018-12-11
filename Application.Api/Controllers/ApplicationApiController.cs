using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Api
{
    public class ApplicationApiController : Controller
    {
        protected IActionResult InvokeMethod<OUT>(Func<OUT> method)
        {
            try
            {
                return Ok(method());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        protected IActionResult InvokeMethod<IN, OUT>(Func<IN, OUT> method, IN model)
        {
            try
            {
                return Ok(method(model));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        protected IActionResult InvokeMethod<IN>(Action<IN> method, IN model)
        {
            try
            {
                method(model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
