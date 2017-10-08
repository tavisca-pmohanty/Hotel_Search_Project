using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.SessionLog
{
   public class SessionData
    {
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelSearchCriterionData { get; set; } 
    }
}
