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
            //searchTerm = searchTerm.ToUpper();
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

        //private List<string> ParseHotelList(string[] splitString1,string[] splitString2,string[] splitString3)
        //{
        //    List<string> hotelList = new List<string>();
        //    for (int i = 0; i < splitString1.Length; i++)
        //    {
        //        string str = splitString1[i];
        //        string []s = Regex.Split(str, ",\"SubItemList\":");
        //       for(int j=0;j<s.Length;j++)
        //        {
        //            hotelList.Add(s[j]);
        //        }
        //    }
        //    for (int i = 0; i < splitString2.Length; i++)
        //    {
        //        string str = splitString1[i];
        //        string[] s = Regex.Split(str, ",\"SubItemList\":");
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            hotelList.Add(s[j]);
        //        }
        //    }
        //    for (int i = 0; i < splitString3.Length; i++)
        //    {
        //        string str = splitString1[i];
        //        string[] s = Regex.Split(str, ",\"SubItemList\":");
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            hotelList.Add(s[j]);
        //        }
        //    }
        //    return hotelList;
        //}
    }
}
