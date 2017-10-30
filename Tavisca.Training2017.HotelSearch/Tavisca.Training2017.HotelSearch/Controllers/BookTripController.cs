﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using HotelSearchEngine;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("book/tripfolder")]
    public class BookTripController : Controller
    {
        [Route("BookTrip")]
        [HttpPost]
        public async Task GetBookTripFolder([FromBody] string requestData)
        {
            try
            {
                ServiceRepository repository = new ServiceRepository();
                var service = repository.GetService("BookTrip");
                string requestedData = await service.GetRequestedDataAsync(requestData);
                await HttpContext.Response.WriteAsync(requestedData);
            }
            catch(Exception ex)
            {
                Logger.Log.LogError(ex);
                throw ex;
            }
        }
    }
}
