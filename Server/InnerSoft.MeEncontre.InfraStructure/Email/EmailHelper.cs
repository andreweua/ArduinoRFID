using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Configuration;
using System.Web;
using System.Web.Configuration;


namespace MeEncontre.Infrastructure.Email
{
    public static class EmailHelper
    { 
        public static void Send(string Remetente, string Destinatario, string Assunto, string Corpo)
        {
            
            MailMessage message = new MailMessage();
            message.From = new MailAddress(Remetente);
 
            message.To.Add(new MailAddress(Destinatario));
 
            message.Subject = Assunto;
            message.Body = Corpo;
            message.IsBodyHtml = true;

            //SmtpClient client = new SmtpClient("mail.aquadroid.com.br");
            SmtpClient client = new SmtpClient();
            //SmtpClient client = new SmtpClient("smtp.gmail.com");
            
            
            //client.Port = 25;
            //client.Credentials = new System.Net.NetworkCredential("aquadroidbr@gmail.com", "aquadroid!1");
            //client.Credentials = new System.Net.NetworkCredential("noreply@aquadroid.com.br", "noreply!1");
            //client.Credentials = new System.Net.NetworkCredential("aquadroi", "073PjLy1xr");
            //client.EnableSsl = true;
            
            client.Send(message);

            //Mail settings

            //Catch all email with your default email account

            //POP3 Host Address : mail.aquadroid.com.br
            //SMTP Host Address: mail.aquadroid.com.br
            //Username: aquadroi
            //Password: 073PjLy1xr

            //Additional mail accounts that you add

            //POP3 Host Address : mail.aquadroid.com.br
            //SMTP Host Address: mail.aquadroid.com.br
            //Username : The FULL email address that you are picking up from (e.g. info@yourdomain.com). 
            //If your email client cannot accept a @ symbol, then you may replace this with a backslash .
            //Password : As specified in your control panel

        }      
    }
}
