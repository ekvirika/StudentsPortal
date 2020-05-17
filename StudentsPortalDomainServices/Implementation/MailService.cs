using MailKit.Net.Smtp;
using MimeKit;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsPortalDomainServices.Implementation
{
    public class MailService : IMailService
    {
        public bool SendMail(IMail mailInfo)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(mailInfo.From, mailInfo.SenderMail));
                mail.To.Add(new MailboxAddress(mailInfo.To));
                mail.Subject = mailInfo.Subject;
                mail.Body = new TextPart("plain") { Text = mailInfo.Body };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("smtpacc123456@gmail.com", "smtpsmtp123456");
                    client.Send(mail);
                    client.Disconnect(true);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
