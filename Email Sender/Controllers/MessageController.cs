
using Microsoft.AspNetCore.Http;
using Email_Sender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly MessageContext _dbContext;

    public MessagesController(MessageContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public ActionResult<Message> GetById(int id)
    {
        var message = _dbContext.GetById(id);

        if (message == null)
        {
            return NotFound();
        }

        return Ok(message);
    }
    //GetMessageById
    [HttpGet]
    public async Task<IEnumerable<Message>> Get()
    {
        return await _dbContext.Messages.ToListAsync();
    }

    [HttpPost("message")]

    public async Task<ActionResult<Message>> Post(Message message)
    {
        _dbContext.Messages.Add(message);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = message.Id }, message);
    }



    //public void SendEmail(string subject, string body, List<string> recipients)
    //{
    //    var fromAddress = new MailAddress("your-email@example.com", "Your Name");
    //    var toAddresses = recipients.Select(r => new MailAddress(r));

    //    var smtp = new SmtpClient
    //    {
    //        Host = "smtp.gmail.com",
    //        Port = 587,
    //        EnableSsl = true,
    //        DeliveryMethod = SmtpDeliveryMethod.Network,
    //        UseDefaultCredentials = false,
    //        Credentials = new NetworkCredential("your-email@example.com", "your-password")
    //    };

    //    using (var message = new MailMessage
    //    {
    //        From = fromAddress,
    //        Subject = subject,
    //        Body = body,
    //        IsBodyHtml = true
    //    })
    //    {
    //        foreach (var toAddress in toAddresses)
    //        {
    //            message.To.Add(toAddress);
    //        }

    //        smtp.Send(message);
    //    }
    //}



}

