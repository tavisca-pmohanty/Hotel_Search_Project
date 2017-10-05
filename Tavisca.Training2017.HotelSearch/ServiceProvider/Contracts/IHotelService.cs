
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public interface IHotelService
    {
        Task<List<HotelSuggestionRS>> GetHotelSuggestion(string searchTerm);
    }
}
