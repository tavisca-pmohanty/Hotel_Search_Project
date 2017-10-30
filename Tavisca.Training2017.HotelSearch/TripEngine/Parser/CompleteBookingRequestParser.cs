using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngineServices;

namespace TripEngine.Parser
{
    public class CompleteBookingRequestParser
    {
        public async Task<CompleteBookingRQ> ParserAsync(TripFolderBookRS request)
        {
            CompleteBookingRQ completeBookingRQ = new CompleteBookingRQ();
            completeBookingRQ.SessionId = request.SessionId;
            completeBookingRQ.ResultRequested = ResponseType.Unknown;
            completeBookingRQ.ExternalPayment = new CreditCardPayment();
            completeBookingRQ.TripFolderId = request.TripFolder.Id;
            completeBookingRQ.ExternalPayment.Attributes=new StateBag[]
             {
               new StateBag()
               {
                   Name = "PointOfSaleRule",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "SectorRule",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "_AttributeRule_Rovia_Username",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "_AttributeRule_Rovia_Password",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "AmountToAuthorize",
                   Value = "1"
               },
               new StateBag()
               {
                   Name = "IsDefaultDollerAuthorization",
                   Value = "Y"
               },
               new StateBag()
               {
                   Name = "PaymentStatus",
                   Value = "Authorization successful"
               },
               new StateBag()
               {
                   Name = "AuthorizationTransactionId",
                   Value = "daa73e68-f46f-4035-94d5-df80a77c1c62"
               },
               new StateBag()
               {
                   Name = "ProviderAuthorizationTransactionId",
                   Value = "DEF127D6-9257-43D3-AA45-92E53AA59CAE"
               },
               new StateBag()
               {
                   Name = "PointOfSaleRule",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "SectorRule",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "_AttributeRule_Rovia_Username",
                   Value = "true"
               },
               new StateBag()
               {
                   Name = "_AttributeRule_Rovia_Password",
                   Value = "true"
               }
           };
            return completeBookingRQ;
        }
    }
}
