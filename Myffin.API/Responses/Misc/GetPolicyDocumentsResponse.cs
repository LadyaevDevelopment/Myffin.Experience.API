using Myffin.API.Models;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Myffin.API.Responses.Misc
{
    public class GetPolicyDocumentsResponse
    {
        [Required]
        [GenericArgumentsNotNull]
        public List<PolicyDocumentModel> Documents { get; set; }

        public GetPolicyDocumentsResponse(List<PolicyDocumentModel> documents)
        {
            Documents = documents;
        }
    }
}