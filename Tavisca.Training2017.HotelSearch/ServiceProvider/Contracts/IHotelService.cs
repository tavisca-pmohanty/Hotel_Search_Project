
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public interface IHotelService
    {
        Task<string> GetData(string searchTerm);
    }
}
