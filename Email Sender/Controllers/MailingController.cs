using Email_Sender.Dtos;
using Email_Sender.Models;
using Email_Sender.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.IO;
using System.Threading.Tasks;


namespace Email_Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


   
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;


       


        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
            
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        //{
        //    var messages = await _messageRepository.GetAllAsync();
        //    return Ok(messages);
        //}

        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto dto)
        {
            var emails = dto.ToEmail.Split(',');
            foreach (var email in emails)
            {
                await _mailingService.SendEmailAsync(email, dto.Subject, dto.Body, dto.Attachments);

            }
            return Ok();
        }


        //[HttpPost]
        //[Route("send")]
        //public async Task<IActionResult> SendMessagesToEmails([FromBody] MailRequestDto dto)
        //{
        //    var messages = await _messageRepository.GetSelectedMessagesAsync(dto.MessageIds);

        //    foreach (var message in messages)
        //    {
        //        await _mailingService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body, dto.Attachments);
        //    }

        //    return Ok();
        //}


    }
}
