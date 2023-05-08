using Myffin.API.Models;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Myffin.API.Responses.Misc
{
    public class GetPolicyDocumentsResponse
    {
        [Required]
        [GenericArgumentsNotNull]
        public List<PolicyDocument> Documents { get; set; }

        public GetPolicyDocumentsResponse(List<PolicyDocument> documents)
        {
            Documents = documents;
        }
    }
}