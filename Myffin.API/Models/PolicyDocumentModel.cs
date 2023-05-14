using System.ComponentModel.DataAnnotations;

namespace Myffin.API.Models
{
    public class PolicyDocumentModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public PolicyDocumentModel(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}