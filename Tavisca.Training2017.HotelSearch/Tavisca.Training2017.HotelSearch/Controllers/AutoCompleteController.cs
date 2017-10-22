using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Logger;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("index/AutoComplete")]
    public class AutoCompleteController : Controller
    {
        // GET: api/values
        [Route("search/{searchTerm}")]
        [HttpGet]
        public async Task GetHotelSuggestionAsync(string searchTerm)
        {
            try
            {
                ServiceRepository repository = new ServiceRepository();
                var service = repository.GetService("AutoComplete");
                var hotelList = await service.GetRequestedDataAsync(searchTerm);
                await HttpContext.Response.WriteAsync(hotelList);
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
            }
            
        }
    }
}
