using Microsoft.AspNetCore.Mvc;
using Myffin.API.Responses;
using Myffin.API.Responses.Misc;

namespace Myffin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiscController: ControllerBase
    {
        [HttpGet]
        [Route("PolicyDocuments")]
        public ResponseWrapper<GetPolicyDocumentsResponse> GetPolicyDocuments()
        {
            return new ResponseWrapper<GetPolicyDocumentsResponse>(OperationStatus.Success)
            {
                ResponseData = new GetPolicyDocumentsResponse(
                    new List<Models.PolicyDocument>()
                    {
                        new Models.PolicyDocument("Privacy Policy", "https://pravo.ru/story/238705/"),
                        new Models.PolicyDocument("Esign Consent", "https://pravo.ru/story/238705/"),
                        new Models.PolicyDocument("T&Cs", "https://pravo.ru/story/238705/"),
                        new Models.PolicyDocument("Communication Policy", "https://pravo.ru/story/238705/"),
                    }
                )
            };
        }
    }
}