using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmsGenerator;
using Newtonsoft.Json;
using Logger;

namespace ServiceProvider
{
    public class MessageService:IHotelService
    {
        SmsNotification smsNotification;
        public MessageService()
        {
            smsNotification = new SmsNotification();
        }

        public async Task<string> GetRequestedDataAsync(string searchTerm)
        {
            try
            {
                var response = await smsNotification.GetMessage(searchTerm);
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
    }
}
