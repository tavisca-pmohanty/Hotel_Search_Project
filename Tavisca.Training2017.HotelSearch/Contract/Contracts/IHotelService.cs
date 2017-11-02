using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelContract.Contracts
{
    public interface IHotelService
    {
        Task<string> GetRequestedDataAsync(string request);
    }
}
