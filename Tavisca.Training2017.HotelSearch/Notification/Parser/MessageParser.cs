using Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Parser
{
    public class MessageParser
    {
        private Dictionary<Attachment[], AttachmentData[]> dict = new Dictionary<Attachment[], AttachmentData[]>();
        MailMessage mailMessage;
        public MessageParser()
        {
            mailMessage = new MailMessage();
        }

        public async Task<MailMessage> ParserAsync(Email email)
        {
            mailMessage.BCC = email.BCCField;
            mailMessage.CC = email.CCField;
            mailMessage.Id = email.GuidId;
            mailMessage.SentDate = email.SentDateField;
            mailMessage.Status = Parse(email.DelieveryStatus);
            mailMessage.IsHtml = email.IsHtmlField;
            mailMessage.From = email.FromField;
            mailMessage.To = email.ToField;
            mailMessage.Subject = email.SubjectField;
            mailMessage.Tags = email.TagsField;
            mailMessage.Attachments = Parser(email.AttachmentsField);
            mailMessage.Body = email.Body;
            return  mailMessage;
        }
        private Dictionary<EmailDelieveryStatus, DeliveryStatus> dictionary = new Dictionary<EmailDelieveryStatus, DeliveryStatus>()
        {
            {
                EmailDelieveryStatus.All,DeliveryStatus.All
             },
            {
                EmailDelieveryStatus.Sent,DeliveryStatus.Sent
             },
            {
                EmailDelieveryStatus.SentSuccessful,DeliveryStatus.SentSuccessful
             },
            {
                EmailDelieveryStatus.FailureRetry,DeliveryStatus.FailureRetry
             },
            {
                EmailDelieveryStatus.Failed, DeliveryStatus.Failed
            }
        };

        public DeliveryStatus Parse(EmailDelieveryStatus mailMessage)
        {
            return dictionary[mailMessage];
        }
        public Attachment[] Parser(AttachmentData[] attachmentData)
        {
            Attachment[] attach = null;
            for (int i = 0; i < 3; i++)
            {
                if ((mailMessage.AttachmentsField[i].FileName == attachmentData[i].FileNameField) && (mailMessage.AttachmentsField[i].FileExtension == attachmentData[i].FileExtensionField) && (mailMessage.AttachmentsField[i].AttachmentFile == attachmentData[i].AttachmentFileField)
                {
                    attach[i] = (Attachment)attachmentData[i];
                    dict.Add(attach, attachmentData);
                }
            }
           
            return attach;
        }


    }
}



