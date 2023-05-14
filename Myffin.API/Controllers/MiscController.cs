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
                    new List<PolicyDocumentModel>()
                    {
                        new PolicyDocumentModel("Privacy Policy", "https://pravo.ru/story/238705/"),
                        new PolicyDocumentModel("Esign Consent", "https://pravo.ru/story/238705/"),
                        new PolicyDocumentModel("T&Cs", "https://pravo.ru/story/238705/"),
                        new PolicyDocumentModel("Communication Policy", "https://pravo.ru/story/238705/"),
                    }
                )
            };
        }
    }
}