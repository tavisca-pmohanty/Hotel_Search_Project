
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public interface Notifier
    {
        Task<string> GetRequestedDataAsync(string searchTerm);
    }
}
