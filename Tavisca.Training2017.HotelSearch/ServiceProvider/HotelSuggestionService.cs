using AutoComplete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Logger;
using HotelContract.Model;
using HotelContract.Contracts;

namespace ServiceProvider
{
    public class HotelSuggestionService:IHotelService
    {
        List<HotelSuggestionRS> hotelList;
        public HotelSuggestionService()
        {
            hotelList = new List<HotelSuggestionRS>();
        }
        public async Task<string> GetRequestedDataAsync(string searchTerm)
        {
            try
            {
                SearchHotelSuggestion search = new SearchHotelSuggestion();
                hotelList = await search.GetSearchQueryData(searchTerm);
                var json = JsonConvert.SerializeObject(hotelList);
                return json;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
        
    }
}
