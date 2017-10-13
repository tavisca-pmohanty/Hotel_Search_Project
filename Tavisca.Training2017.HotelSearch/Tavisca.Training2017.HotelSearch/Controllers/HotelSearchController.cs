using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceProvider;
using Microsoft.AspNetCore.Http;

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("index/hotelListing/search")]
    public class HotelSearchController : Controller
    {
        [Route("GetHotels")]
        [HttpPost]
        public async Task GetHotelListing([FromBody]string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("HotelListing");
            string hotelListing = await service.GetRequestedData(requestData);
            await HttpContext.Response.WriteAsync(hotelListing);
        }


        [Route("GetHotelRooms")]
        [HttpPost]
        public async Task GetHotelRooms([FromBody]string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("HotelRooms");
            string hotelListing = await service.GetRequestedData(requestData);
            await HttpContext.Response.WriteAsync(hotelListing);
        }

        [Route("GetRoomPricing")]
        [HttpPost]
        public async Task GetRoomPrice([FromBody] string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("RoomPricing");
            string roomPricingData = await service.GetRequestedData(requestData);
            await HttpContext.Response.WriteAsync(roomPricingData);
        }
    }
}
