using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoComplete
{
    public class SearchHotelSuggestion
    {
        public async Task<string> GetSearchQueryData(string searchTerm)
        {
            WebRequest req = WebRequest.Create(@"http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=city|airport|poi&query=" + searchTerm);

            req.Method = "GET";
            string hotelList = "";
            WebResponse resp = await req.GetResponseAsync();
            if (resp.ContentLength != 0)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    hotelList = reader.ReadToEnd();
                }
            }
           
            return hotelList;
        }
    }
}
