using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Myffin.API.Responses;

namespace Myffin.API.Versioning
{
    public class ApiVersionErrorProvider : IErrorResponseProvider
    {
        public IActionResult CreateResponse(ErrorResponseContext context)
        {
            return new JsonResult(new ResponseWrapper<EmptyResponse>(OperationStatus.UnsupportedApiVersion));
        }
    }
}