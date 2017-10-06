using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Contracts
{
    interface IHotelSuggestion
    {
        Task<List<HotelSuggestionRS>> GetHotelSuggestion(string searchTerm);
    }
}
