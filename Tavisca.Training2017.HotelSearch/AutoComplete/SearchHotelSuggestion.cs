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
        public async Task<string[]> GetSearchQueryData(string searchTerm)
        {
            searchTerm=searchTerm.ToUpper();
            WebRequest req = WebRequest.Create(@"http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=hotel%7Cpoi&query="+searchTerm);

            req.Method = "GET";
            string s = "";
            WebResponse resp = await req.GetResponseAsync();
            if (resp.ContentLength !=0)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    s = reader.ReadToEnd();
                }
            }
            string reg = "\"ItemList\":\\[";
            string[] str = Regex.Split(s,reg);
            string[] splitString = Regex.Split(str[1],"},",RegexOptions.IgnoreCase);
            string[] hotelList = ParseHotelList(splitString);
            return hotelList;
        }

        private string[] ParseHotelList(string[] splitString)
        {
            string[] hotelList= new string[splitString.Length];
            for(int i=0;i<splitString.Length;i++)
            {
                string str = splitString[i];
                string []s = Regex.Split(str, ",\"SubItemList\":");
                hotelList[i] = s[0];
            }
            return hotelList;
        }
    }
}
