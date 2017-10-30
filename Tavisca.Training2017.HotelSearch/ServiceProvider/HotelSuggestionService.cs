using AutoComplete;
using ServiceProvider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Json;
using Newtonsoft.Json;
using HotelEngienSearch;
using Logger;
using AutoComplete.Model;
using AutoComplete.Contract;

namespace ServiceProvider
{
    public class HotelSuggestionService:IHotelService
    {
        List<IResponse> hotelList;
        public HotelSuggestionService()
        {
            hotelList = new List<IResponse>();
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
