﻿using HotelContract.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter.Parser
{
    public class HotelSuggesstionRSParser
    {
        List<HotelSuggestionRS> hotelSuggestionList;
        public HotelSuggesstionRSParser()
        {
            hotelSuggestionList = new List<HotelSuggestionRS>();
        }
        public async Task<List<HotelSuggestionRS>> ParseHoteLDataAsync(string hotelData)
        {
            string[] hotels = hotelData.Split(new string[] { "\"SubItemList\":null}," }, StringSplitOptions.None);
            for (int i = 1; i < hotels.Length; i++)
            {
                string[] id = hotels[i].Split(new string[] { "\"Id\":", "," }, 3, StringSplitOptions.None);
                string[] hotelName = id[2].Split(new string[] { "\"Name\":", "," }, 3, StringSplitOptions.None);
                string[] code = hotelName[2].Split(new string[] { "\"Code\":", "," }, 3, StringSplitOptions.None);
                string[] cityName = code[2].Split(new string[] { "\"CityName\":", "," }, 3, StringSplitOptions.None);
                string[] cityCode = cityName[2].Split(new string[] { "\"CityCode\":", "," }, 3, StringSplitOptions.None);
                string[] stateCode = cityCode[2].Split(new string[] { "\"StateCode\":", "," }, 3, StringSplitOptions.None);
                string[] countryCode = stateCode[2].Split(new string[] { "\"CountryCode\":", "," }, 3, StringSplitOptions.None);
                string[] latitude = countryCode[2].Split(new string[] { "\"Latitude\":", "," }, 3, StringSplitOptions.None);
                string[] longitude = latitude[2].Split(new string[] { "\"Longitude\":", "," }, 3, StringSplitOptions.None);
                string[] searchType = longitude[2].Split(new string[] { "\"SearchType\":", "," }, 3, StringSplitOptions.None);
                string[] culteredText = searchType[2].Split(new string[] { "\"CulturedText\":", ",\"" }, 3, StringSplitOptions.None);
                id[1] = id[1].Replace('\"', ' ');
                hotelName[1] = hotelName[1].Replace('\"', ' ');
                cityName[1] = cityName[1].Replace('\"', ' ');
                stateCode[1] = stateCode[1].Replace('\"', ' ');
                countryCode[1] = countryCode[1].Replace('\"', ' ');
                latitude[1] = latitude[1].Replace('\"', ' ');
                longitude[1] = longitude[1].Replace('\"', ' ');
                searchType[1] = searchType[1].Replace('\"', ' ');
                culteredText[1] = culteredText[1].Replace('\"', ' ');
                id[1] = id[1].Trim();
                hotelName[1] = hotelName[1].Trim();
                cityName[1] = cityName[1].Trim();
                stateCode[1] = stateCode[1].Trim();
                countryCode[1] = countryCode[1].Trim();
                latitude[1] = latitude[1].Trim();
                longitude[1] = longitude[1].Trim();
                searchType[1] = searchType[1].Trim();
                culteredText[1] = culteredText[1].Trim();
                var response = new HotelSuggestionRS(id[1], hotelName[1], cityName[1], stateCode[1], countryCode[1], latitude[1], longitude[1], searchType[1], culteredText[1]);
                hotelSuggestionList.Add(response);
            }
            return hotelSuggestionList;
        }
    }
}
