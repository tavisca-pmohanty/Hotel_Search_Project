using AutoComplete;
using ServiceProvider.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Json;
using Newtonsoft.Json;

namespace ServiceProvider
{
    public class HotelSuggestionService:IHotelService
    {
        List<HotelSuggestionRS> hotelList;
        public HotelSuggestionService()
        {
            hotelList = new List<HotelSuggestionRS>();
        }
        public async Task<string> GetHotelSuggestion(string searchTerm)
        {
            SearchHotelSuggestion search = new SearchHotelSuggestion();
            var suggestionResponse= await search.GetSearchQueryData(searchTerm);
            ParseHoteLData(suggestionResponse);
            var json = JsonConvert.SerializeObject(hotelList);
            return json;
        }
        public void ParseHoteLData(string []hotelData)
        {
            for(int i=0;i<hotelData.Length;i++)
            { 
                string []id = hotelData[i].Split(new string[] { "\"Id\":","," },3, StringSplitOptions.None);
                string []hotelName= id[2].Split(new string[] { "\"Name\":", "," },3,StringSplitOptions.None);
                string[] code = hotelName[2].Split(new string[] { "\"Code\":", "," }, 3, StringSplitOptions.None);
                string []cityName= code[2].Split(new string[] { "\"CityName\":", "," },3, StringSplitOptions.None);
                string[] cityCode = cityName[2].Split(new string[] { "\"CityCode\":", "," }, 3, StringSplitOptions.None);
                string []stateCode= cityCode[2].Split(new string[] { "\"StateCode\":", "," }, 3,StringSplitOptions.None);
                string []countryCode= stateCode[2].Split(new string[] { "\"CountryCode\":", "," }, 3,StringSplitOptions.None);
                string []latitude= countryCode[2].Split(new string[] { "\"Latitude\":", "," }, 3,StringSplitOptions.None);
                string []longitude= latitude[2].Split(new string[] { "\"Longitude\":", "," }, 3,StringSplitOptions.None);
                string []searchType= longitude[2].Split(new string[] { "\"SearchType\":","," },3,StringSplitOptions.None);
                string []culteredText=searchType[2].Split(new string[] { "\"CulturedText\":",",\"" }, 3, StringSplitOptions.None);
                id[1]= id[1].Replace('\"',' ');
                hotelName[1]=hotelName[1].Replace('\"', ' ');
                cityName[1]=cityName[1].Replace('\"', ' ');
                stateCode[1]=stateCode[1].Replace('\"', ' ');
                countryCode[1]=countryCode[1].Replace('\"', ' ');
                latitude[1]=latitude[1].Replace('\"', ' ');
                longitude[1]=longitude[1].Replace('\"', ' ');
                searchType[1]=searchType[1].Replace('\"', ' ');
                culteredText[1] = culteredText[1].Replace('\"', ' ');
                id[1]=id[1].Trim();
                hotelName[1] = hotelName[1].Trim();
                cityName[1] = cityName[1].Trim();
                stateCode[1] = stateCode[1].Trim();
                countryCode[1] = countryCode[1].Trim();
                latitude[1] = latitude[1].Trim();
                longitude[1] = longitude[1].Trim();
                searchType[1] = searchType[1].Trim();
                culteredText[1] = culteredText[1].Trim();
                var response = new HotelSuggestionRS(id[1],hotelName[1],cityName[1],stateCode[1],countryCode[1],latitude[1],longitude[1],searchType[1],culteredText[1]);
                hotelList.Add(response);
            }
        }
    }
}
