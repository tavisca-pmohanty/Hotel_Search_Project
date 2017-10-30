using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class BookTripFolderResponse:IResponse
    {
        public string SessionId { get; set; }
    }
}
