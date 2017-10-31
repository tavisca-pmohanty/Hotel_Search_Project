using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Contracts
{
    public interface IParser
    {
        Task<IResponse> ParserAsync(IRequest request);
    }
}
