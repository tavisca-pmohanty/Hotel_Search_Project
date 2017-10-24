using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceProvider;
using Microsoft.AspNetCore.Http;

using System;
using TripEngineServices;

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("index/hotelListing/search")]
    public class HotelSearchController : Controller
    {
        [Route("GetHotels")]
        [HttpPost]
        public async Task GetHotelListingAsync([FromBody]string requestData)
        {
            if (requestData == null)
            {
                BadRequest();
            }
            else
            {
                try
                {
                    ServiceRepository repository = new ServiceRepository();
                    var service = repository.GetService("HotelListing");
                    string hotelListing = await service.GetRequestedDataAsync(requestData);
                    await HttpContext.Response.WriteAsync(hotelListing);
                }
                catch(Exception ex)
                {
                    Logger.Log.LogError(ex);
                    throw ex;
                }
            }
        }


        [Route("GetHotelRooms")]
        [HttpPost]
        public async Task GetHotelRoomsAsync([FromBody]string requestData)
        {
            if (requestData == null)
            {
                BadRequest();
            }
            else
            {
                try
                {
                    ServiceRepository repository = new ServiceRepository();
                    var service = repository.GetService("HotelRooms");
                    string hotelListing = await service.GetRequestedDataAsync(requestData);
                    await HttpContext.Response.WriteAsync(hotelListing);
                }
                catch(Exception ex)
                {
                    Logger.Log.LogError(ex);
                    throw ex;
                }
            }
        }

        [Route("GetRoomPricing")]
        [HttpPost]
        public async Task GetRoomPriceAsync([FromBody] string requestData)
        {
            if (requestData == null)
            {
                BadRequest();
            }
            else
            {
                try
                {
                    ServiceRepository repository = new ServiceRepository();
                    var service = repository.GetService("RoomPricing");
                    string roomPricingData = await service.GetRequestedDataAsync(requestData);
                    await HttpContext.Response.WriteAsync(roomPricingData);
                }
                catch(Exception ex)
                {
                    Logger.Log.LogError(ex);
                    throw ex;
                }
            }
        }
        [Route("GetBookingDetails")]
        [HttpPost]
        public async Task GetBookingDetail([FromBody] string requestData)
        {
            try
            {

                ServiceRepository repository = new ServiceRepository();
                var service = repository.GetService("CompleteBooking");
                string bookingData = await service.GetRequestedDataAsync(requestData);
                await HttpContext.Response.WriteAsync(bookingData);
            }
            catch(Exception ex)
            {
                Logger.Log.LogError(ex);
                throw ex;
            }
        }

        //[Route("index/")]
        //public class CompleteBooKingParser : Controller
        //{
        //    [HttpGet("book")]

        //    public async Task<CompleteBookingRS> BookRequest()
        //    {
        //        CompleteBookingRQ CompleteBookingRequestParser = new CompleteBookingRQ()
        //        {
        //            ResultRequested = ResponseType.Unknown,
        //            SessionId = Guid.NewGuid().ToString(),
        //            ExternalPayment = new CreditCardPayment()
        //            {
        //                Amount = new Money()
        //                {
        //                    BaseEquivAmount = 0M,
        //                    BaseEquivCurrency = "USD",
        //                    Currency = "USD",
        //                    DisplayAmount = 41.20M,
        //                    Amount = 41.20M,
        //                    DisplayCurrency = "USD",
        //                    UsdEquivAmount = 0M
        //                },
        //                Attributes = new StateBag[]
        //                     {
        //               new StateBag()
        //               {
        //                   Name ="PointOfSale",
        //                   Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="SectorRule",
        //                   Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="_AttributeRule_Rovia_Username",
        //                   Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="_AttributeRule_Rovia_Password",
        //                   Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="AmountToAuthorize",
        //                   Value = "1"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="IsDefaultDollerAuthorization",
        //                   Value = "Y"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="PaymentStatus",
        //                  Value = "Authorization successful"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="AuthorizationTransactionId",
        //                   Value = "daa73e68-f46f-4035-94d5-df80a77c1c62"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="ProviderAuthorizationTransactionId",
        //                    Value = "DEF127D6-9257-43D3-AA45-92E53AA59CAE"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="PointOfSaleRule",
        //                     Value = "true"

        //               },
        //               new StateBag()
        //               {
        //                   Name ="SectorRule",
        //                     Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="_AttributeRule_Rovia_Username",
        //                   Value = "true"
        //               },
        //               new StateBag()
        //               {
        //                   Name ="_AttributeRule_Rovia_Password",
        //                   Value = "true"
        //               },
        //                     },
        //                BillingAddress = new Address()
        //                {
        //                    CodeContext = LocationCodeContext.Address,
        //                    GmtOffsetMinutes = 0,
        //                    Id = 0,
        //                    AddressLine1 = "5360 Legacy Drive Suite 300",
        //                    City = new City
        //                    {
        //                        CodeContext = LocationCodeContext.City,
        //                        GmtOffsetMinutes = 0,
        //                        Id = 0,
        //                        Name = "Plano",
        //                        Country = "US",
        //                        State = "TX"
        //                    },
        //                    PhoneNumber = "1214 - 231 - 5445",
        //                    ZipCode = "75024"
        //                },
        //                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        //                PaymentType = PaymentType.Credit,
        //                Rph = 0,
        //                CardMake = new CreditCardMake()
        //                {
        //                    Code = "VI",
        //                    Name = "Visa"
        //                },
        //                CardType = CreditCardType.Personal,
        //                ExpiryMonthYear = new DateTime(2019, 01, 01),
        //                IsThreeDAuthorizeRequired = false,
        //                NameOnCard = "Saurabh Cache",
        //                Number = "0000000000001111",
        //                SecurityCode = "123"
        //            },
        //            TripFolderId = Guid.Parse("bb900986-6117-40f5-8d2e-f72a32ea5185")
        //        };
        //        CompleteBookingRS result = null;
        //        try
        //        {
        //            TripsEngineClient tripsEngineClient = new TripsEngineClient();
        //            result = await tripsEngineClient.CompleteBookingAsync(CompleteBookingRequestParser);
        //        }
        //        catch (Exception ex)
        //        {

        //            Logger.Log.LogError(ex);
        //        }
        //        return result;
        //    }
            
        }

    }
