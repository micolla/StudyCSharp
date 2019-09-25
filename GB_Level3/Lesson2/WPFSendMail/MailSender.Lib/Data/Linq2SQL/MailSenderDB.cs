using System.Linq;
namespace MailSender.Lib.Data.Linq2SQL
{
    partial class MailSenderDBDataContext
    {
        public IQueryable<Recipient> Recipients {
            get
            { return from c in Recipient select c; }
        }
    }
}