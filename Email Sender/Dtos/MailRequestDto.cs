using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Email_Sender.Dtos
{
    public class MailRequestDto
    {
        [Required]
        public string ToEmail { get; set; }

        //public IList<IFormCollection> ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IList<IFormFile> Attachments { get; set; }
    }
}
