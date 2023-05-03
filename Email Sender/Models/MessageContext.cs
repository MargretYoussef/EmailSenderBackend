using Email_Sender.Models;
using Email_Sender.Settings;
using Microsoft.EntityFrameworkCore;

namespace Email_Sender.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
         : base(options)
        {
        }


        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=EmailSender; Integrated Security=True; TrustServerCertificate= True");
      
        }

        internal object GetById(int id)
        {
            return Messages.SingleOrDefault(x => x.Id == id);

        }
    }
}



