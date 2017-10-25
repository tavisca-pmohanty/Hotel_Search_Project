using Microsoft.AspNetCore.Mvc;
using ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("/Notification")]
    public class Notification
    {

        [Route("Get/Notification")]
        [HttpPost]
        public async Task GetNotification([FromBody] string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("Notification");

        }
    }
}
//[Route("complete/booking")]
//public class CompleteBookingController : Controller
//{
//    [Route("bookingcomplete")]
//    [HttpPost]
//    public async Task GetBookTripFolder([FromBody] string requestData)
//    {
//        try
//        {
//            ServiceRepository repository = new ServiceRepository();
//            var service = repository.GetService("CompleteBooking");
//            string requestedData = await service.GetRequestedDataAsync(requestData);
//            await HttpContext.Response.WriteAsync(requestedData);
//        }
//        catch (Exception ex)
//        {
//            Logger.Log.LogError(ex);
//            throw ex;
//        }
//    }
//}