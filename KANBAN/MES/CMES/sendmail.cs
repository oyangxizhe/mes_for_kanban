using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;


namespace CMES
{
    /// <summary>
    /// 發信類別庫
    /// </summary>
    public class SendMail
    {
        private string smtp = "mail.acesconn.com";
        public SendMail() { LIST = list; }
        List<string> list2 = new List<string> {
            "matthew@acesconn.com", 
            "mirror@acesconn.com",
            "david0919@acesconn.com",
            "ksmis-soft@acesconn.com" };
        List<string> list = new List<string> {"ksmis-soft@acesconn.com" };
        private List<string> _LIST;
        public List<string> LIST
        {
            set { _LIST = value; }
            get { return _LIST; }
        }
        public SendMail(string subject, string body, List<string> mailto)
        {
            send_email(subject,body,mailto);
        }

        /// <summary>
        /// 寄信方法
        /// </summary>
        /// <param name="subject">信件標題</param>
        /// <param name="body">信件本文</param>
        /// <param name="mailto">收信對象</param>
        public void send_email(string subject,string body, List<string> mailto, string frommail = "mes_admin@acesconn.com")
        {
            if (mailto.Count > 0)
            {
                MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("mail.acesconn.com");
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(frommail);
                foreach (var item in mailto)
                {
                    mail.To.Add(item);
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                //SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Send(mail);
            }
        }
    }
}
