using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("Textmessage")]
    public class TextMessageController : Controller
    {
      
        [Route("SendMessage")]
        [HttpPost]
        public async Task GetSmsNotification([FromBody] string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("SmsAlert");
            string response = await service.GetRequestedDataAsync(requestData);
            await HttpContext.Response.WriteAsync(response);
            
        }
        
    }
}
