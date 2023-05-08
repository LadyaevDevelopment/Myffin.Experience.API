using Microsoft.AspNetCore.Mvc;
using Myffin.API.Models;
using Myffin.API.Responses;
using Myffin.API.Responses.Misc;

namespace Myffin.API.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class MiscController: Controller
    {
        [HttpGet]
        [Route("PolicyDocuments")]
        public ResponseWrapper<GetPolicyDocumentsResponse> GetPolicyDocuments()
        {
            return new ResponseWrapper<GetPolicyDocumentsResponse>(OperationStatus.Success)
            {
                ResponseData = new GetPolicyDocumentsResponse(
                    new List<PolicyDocument>()
                    {
                        new PolicyDocument("Privacy Policy", "https://pravo.ru/story/238705/"),
                        new PolicyDocument("Esign Consent", "https://pravo.ru/story/238705/"),
                        new PolicyDocument("T&Cs", "https://pravo.ru/story/238705/"),
                        new PolicyDocument("Communication Policy", "https://pravo.ru/story/238705/"),
                    }
                )
            };
        }
    }
}