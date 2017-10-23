using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    class CompleteBookingService : IHotelService
    {
        public Task<string> GetRequestedDataAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
