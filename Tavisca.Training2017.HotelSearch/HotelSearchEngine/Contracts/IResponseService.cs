using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Contracts
{
    public interface IResponseService
    {
        Task<IResponse> GetResponseAsync(IRequest request);
    }
}
