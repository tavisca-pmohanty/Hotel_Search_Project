using System;
using TripEngineServices;

public class TripEngineRequestParser
{
    public CompleteBookingRQ GetTripPricing()
    {

        return new CompleteBookingRQ()
        {
            ResultRequested = ResponseType.Unknown,
            SessionId = Guid.NewGuid().ToString(),
            ExternalPayment = new Payment()
            {
                Amount = new Money()
                {
                    BaseEquivAmount = 0,
                    BaseEquivCurrency = "USD",
                    Currency = "USD",
                    DisplayAmount = (decimal)41.2,
                    Amount = (decimal)41.2,
                    DisplayCurrency = "USD",
                    UsdEquivAmount = 0
                },
                Attributes = new StateBag[]
                {
                       new StateBag()
                       {
                           Name ="PointOfSale",
                       },
                       new StateBag()
                       {
                           Name ="SectorRule",
                       },
                       new StateBag()
                       {
                           Name ="_AttributeRule_Rovia_Username",
                       },
                       new StateBag()
                       {
                           Name ="_AttributeRule_Rovia_Password",
                       },
                       new StateBag()
                       {
                           Name ="AmountToAuthorize",
                       },
                       new StateBag()
                       {
                           Name ="IsDefaultDollerAuthorization",
                       },
                       new StateBag()
                       {
                           Name ="PaymentStatus",
                       },
                       new StateBag()
                       {
                           Name ="AuthorizationTransactionId",
                       },
                       new StateBag()
                       {
                           Name ="ProviderAuthorizationTransactionId",
                       },
                       new StateBag()
                       {
                           Name ="PointOfSaleRule",
                       },
                       new StateBag()
                       {
                           Name ="SectorRule",
                       },
                       new StateBag()
                       {
                           Name ="_AttributeRule_Rovia_Username",
                       },
                       new StateBag()
                       {
                           Name ="_AttributeRule_Rovia_Password",
                       },
                },
                BillingAddress = new Address()
                {
                    CodeContext = LocationCodeContext.Address,
                    GmtOffsetMinutes = 0,
                    Id = 0,
                    AddressLine1 = "5360 Legacy Drive Suite 300",
                    City = new City
                    {
                        CodeContext = LocationCodeContext.City,
                        GmtOffsetMinutes = 0,
                        Id = 0,
                        Name = "Plano",
                        Country = "US",
                        State = "TX",
                    },
                    PhoneNumber = "1214 - 231 - 5445",
                    ZipCode = "75024",
                },
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                PaymentType = PaymentType.Credit,
                Rph = 0,

            }
        };
    }
        public async void GetResponse()
        {
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            CompleteBookingRS response=await tripsEngineClient.CompleteBookingAsync(GetTripPricing());
            response = response;
        }
        
        

    
}