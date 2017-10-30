using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Model
{
    public class Email
    {
        public Guid GuidId { get; set; }

        public string FromField { get; set; }

        public string[] ToField { get; set; }

        public string[] CCField { get; set; }

        public string[] BCCField { get; set; }

        public string SubjectField { get; set; }

        public EmailDelieveryStatus DelieveryStatus
        {
            get
            {
                return this.DelieveryStatus;
            }
            set
            {
                this.DelieveryStatus = value;
            }
        }

        public DateTime SentDateField { get; set; }

        public string[] TagsField { get; set; }

        public AttachmentData[] AttachmentsField { get; set; }      

        public string Body { get; set; }

        public bool IsHtmlField { get; set; }

    }

}
