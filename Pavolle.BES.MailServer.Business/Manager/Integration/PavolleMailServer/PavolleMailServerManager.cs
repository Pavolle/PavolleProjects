using Pavolle.BES.MailServer.ViewModels.Model;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager.Integration.PavolleMailServer
{
    public class PavolleMailServerManager : Singleton<PavolleMailServerManager> , IMailServerIntegrationManager
    {
        /*
         * Mail.Host = "mail.alanadi.com"								' mail host adresi 
Mail.Username = "hesap@test.com"							' Mail gönderen hesabın adı
Mail.Password = "Email Sifresi"								' mail gönderen hesabın şifresi
Mail.Port = 587
Mail.From = "hesap@alanadi.com"								' gönderici mail adresi
Mail.FromName = "Web Form"									' Gönderici adı
Mail.AddAddress "alici@test.com", "alici@test.com"			' alıcı adresi ve adı
Mail.AddReplyTo "Destek@alanadi.com"						' Yanıla adresi istenirse kullanılmayabilir.
Mail.Subject = "test"										' mesaj başlığı
Mail.Body = Message	
         */


        string _mailHostname;
        string _mailUsername;
        string _mailPassword;
        int _mailPort;
        SmtpClient _smtpClient;
        private PavolleMailServerManager() 
        {

        }

        public void Initialize()
        {
            _mailHostname = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerPavolleHostname);
            _mailUsername = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerPavolleUsername);
            _mailPassword = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerPavollePassword);
            try
            {
                _mailPort = Convert.ToInt32(SettingServiceManager.Instance.GetSetting(ESettingType.MailServerPavollePort));
            }
            catch (Exception ex)
            {
                _mailPort = 587;
            }

            _smtpClient = new SmtpClient()
            {
                Host = _mailHostname,
                Credentials = new NetworkCredential(_mailUsername, _mailPassword),
                Port = _mailPort
            };
        }

        public void SendMail(List<string> mailTo, List<string> mailInfo, string header, string htmlContent, List<AttachmentModel> attachments)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(MailServerHelperManager.Instance.GetMailAddresses(mailTo)),
                Subject = header,
                Body = htmlContent,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(MailServerHelperManager.Instance.GetMailAddresses(mailInfo));

            if(attachments != null && attachments.Count>0 )
            {
                foreach(var attachment in attachments)
                {
                    //TODO Bu kısım test edilecek.
                    //TODO Burada veriyi dosyaya yazmamız gerekebilir. O yüzden buraya gelen mailde veriyi tmp dosyasına yazıp ondan sonra gönderebiliriz. Daha sonra dosyayı silebiliriz.
                    Attachment data = new Attachment(attachment.FileName, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(attachment.FileName);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachment.FileName);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(attachment.FileName);
                    // Add the file attachment to this e-mail message.
                    mailMessage.Attachments.Add(data);
                }
            }

            _smtpClient.Send(mailMessage);
        }
    }
}
