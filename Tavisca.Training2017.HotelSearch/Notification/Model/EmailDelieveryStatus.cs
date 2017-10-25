using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Model
{
    public enum EmailDelieveryStatus:int
    {
      
        All = 0,
        Sent = 1,
        SentSuccessful = 2,
        FailureRetry = 3,
        Failed = 4,
    }
}
