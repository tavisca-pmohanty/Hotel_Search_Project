using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class NotificationServices : IHotelService
    {

        public Task<string> GetRequestedDataAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
