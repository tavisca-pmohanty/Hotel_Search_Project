using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Logger;
using SmsGenerator.Model;

namespace SmsGenerator
{
    public class SmsNotification
    {

        public async Task<ResponseSms> GetMessage(string request)
        {
            ResponseSms responseSms = new ResponseSms();
            responseSms.Status = StatusType.Failure;
            try
            {
                TwilioClient.Init("ACd295eb50aabe82232e8c765857fbbec0", "71f3852a3cc555c530aef33ec37cf926");

                MessageResource.Create(
         to: new PhoneNumber("+918249123748"),
         from: new PhoneNumber("+17149704389"),
         body: "Hi a Hotel booking is done to your name as");
                responseSms.Status = StatusType.Success;
                return responseSms;
            }

            catch (Exception ex)
            {
                Logger.Log.LogError(ex);
                throw ex;
            }
        }

    }
}
