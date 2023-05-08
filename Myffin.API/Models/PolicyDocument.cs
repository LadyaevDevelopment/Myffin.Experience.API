using System.ComponentModel.DataAnnotations;

namespace Myffin.API.Models
{
    public class PolicyDocument
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public PolicyDocument(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}