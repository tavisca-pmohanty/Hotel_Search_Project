using Microsoft.AspNetCore.Mvc;
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
        public async Task GetNotification([FromBody] string requestData)
        {

        }
    }
}
