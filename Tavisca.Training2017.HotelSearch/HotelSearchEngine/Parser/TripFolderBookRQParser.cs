
using APITripEngine;
using Cache.CacheData;
using HotelSearchEngine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace HotelSearchEngine.Parser
{
    public class TripFolderBookRQparser
    {

        public async Task<TripFolderBookRQ> ParserAsync(HotelSearchBookingRequest request)
        {
            List<HotelCancellationRule> cancellationRuleList = new List<HotelCancellationRule>();
            string jsonItinerary = JsonConvert.SerializeObject(GetCachedItinerary(request.SessionId));
            HotelItinerary itinerary = JsonConvert.DeserializeObject<APITripEngine.HotelItinerary>(jsonItinerary);
            itinerary.HotelCancellationPolicy.CancellationRules = new HotelCancellationRule[]
            {
                new HotelCancellationRule(),
            };
            itinerary.HotelCancellationPolicy.CancellationRules = cancellationRuleList.ToArray();
            string jsonCriterion = JsonConvert.SerializeObject(GetCachedCriterion(request.SessionId));
            HotelSearchCriterion criterion = JsonConvert.DeserializeObject<APITripEngine.HotelSearchCriterion>(jsonCriterion);
            itinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.BaseFare.Amount;
            itinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.BaseFare.Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            itinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            itinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Currency;
            itinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Amount;
            itinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.Taxes[0].Amount;
            itinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.Taxes[0].Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalCommission.Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalCommission.Amount;
            itinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Amount;
            itinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            itinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalTax.Currency;
            itinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalTax.Amount;
            itinerary.Fare.AvgDailyRate.DisplayAmount = itinerary.Fare.AvgDailyRate.Amount;
            itinerary.Fare.AvgDailyRate.DisplayCurrency = itinerary.Fare.AvgDailyRate.Currency;
            itinerary.Fare.BaseFare.DisplayAmount = itinerary.Fare.BaseFare.Amount;
            itinerary.Fare.BaseFare.DisplayCurrency = itinerary.Fare.BaseFare.Currency;
            itinerary.Fare.MaxDailyRate.DisplayAmount = itinerary.Fare.MaxDailyRate.Amount;
            itinerary.Fare.MaxDailyRate.DisplayCurrency = itinerary.Fare.MaxDailyRate.Currency;
            itinerary.Fare.MinDailyRate.DisplayAmount = itinerary.Fare.MinDailyRate.Amount;
            itinerary.Fare.MinDailyRate.DisplayCurrency = itinerary.Fare.MinDailyRate.Currency;
            itinerary.Fare.TotalCommission.DisplayAmount = itinerary.Fare.TotalCommission.Amount;
            itinerary.Fare.TotalCommission.DisplayCurrency = itinerary.Fare.TotalCommission.Currency;
            itinerary.Fare.TotalDiscount.DisplayAmount = itinerary.Fare.TotalDiscount.Amount;
            itinerary.Fare.TotalDiscount.DisplayCurrency = itinerary.Fare.TotalDiscount.Currency;
            itinerary.Fare.TotalFare.DisplayAmount = itinerary.Fare.TotalFare.Amount;
            itinerary.Fare.TotalFare.DisplayCurrency = itinerary.Fare.TotalFare.Currency;
            itinerary.Fare.TotalFee.DisplayAmount = itinerary.Fare.TotalFee.Amount;
            itinerary.Fare.TotalFee.DisplayCurrency = itinerary.Fare.TotalFee.Currency;
            itinerary.Fare.TotalTax.DisplayAmount = itinerary.Fare.TotalTax.Amount;
            itinerary.Fare.TotalTax.DisplayCurrency = itinerary.Fare.TotalTax.Currency;
            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                SessionId = request.SessionId,
                ResultRequested = ResponseType.Unknown,
                TripFolder = new TripFolder()
                {
                    CreatedDate = DateTime.Now,
                    Creator = new User()
                    {
                        AdditionalInfo = new StateBag[]
                    {
                        new StateBag(){ Name="AgencyName", Value="WV"},
                        new StateBag(){ Name="CompanyName", Value= "Rovia"},
                        new StateBag(){ Name="UserType", Value="Normal"}
                    },
                        Email = "sshrikhande@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "TripFolder" + DateTime.Now,
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    LastModifiedDate = DateTime.Now,
                    Owner = new User()
                    {
                        AdditionalInfo = new StateBag[]
                       {
                            new StateBag()
                            {
                                Name = "AgencyName",
                                Value = "WV"
                            },
                            new StateBag()
                            {
                                Name = "CompanyName",
                                Value = "Rovia"
                            },
                            new StateBag()
                            {
                                Name = "UserType",
                                Value = "Normal"
                            },
                       },
                        Email = "sshrikhande@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    Pos = new PointOfSale()
                    {
                        AdditionalInfo = new StateBag[]
                    {
                            new StateBag() { Name = "IPAddress", Value = "127.0.0.1" },
                            new StateBag() { Name = "DealerUrl", Value = "localhost" },
                            new StateBag() { Name = "SiteUrl", Value = "ota" },
                            new StateBag() { Name = "AccountId", Value = "169050" },
                            new StateBag() { Name = "UserId", Value = "3285301" },
                            new StateBag() { Name = "CountryName", Value = "United States" },
                            new StateBag() { Name = "CountryCode", Value = "US" },
                            new StateBag() { Name = "UserProfileCountryCode", Value = "US" },
                            new StateBag() { Name = "CustomerType", Value = "DTP" },
                            new StateBag() { Name = "DKCommissionIdentifier", Value = "3285301P" },
                            new StateBag() { Name = "MemberSignUpDate", Value = "Tue, 04 Jan 2011" }
                    },
                        PosId = 101,
                        Requester = new Company()
                        {
                            Agency = new Agency()
                            {
                                AgencyAddress = new Address()
                                {
                                    CodeContext = LocationCodeContext.Address,
                                    GmtOffsetMinutes = 0,
                                    Id = 0,
                                    AddressLine1 = "Test1",
                                    AddressLine2 = "Test2",
                                    ZipCode = "890002",
                                    City = new City()
                                    {
                                        CodeContext = LocationCodeContext.City,
                                        GmtOffsetMinutes = 0,
                                        Id = 0,
                                        Name = "Nevada",
                                        Country = "Us",
                                        State = "Nv"

                                    },

                                },
                                AgencyId = 0,
                                AgencyName = "WV",
                            },
                            Code = "DTP",
                            CodeContext = CompanyCodeContext.Airline,
                            DK = "3285301P",
                            FullName = "Rovia",
                            ID = 0,
                        }
                    },
                    Type = TripFolderType.Personal,
                    EndDate = DateTime.Now,
                    Passengers = new Passenger[]
                    {
                    new Passenger()
                    {
                        Age=30,
                        BirthDate=new DateTime(1987,06,16),
                        CustomFields=new StateBag[]
                        {
                            new StateBag(){ Name="Boyd Gaming"},
                            new StateBag(){ Name="IsPassportRequired" , Value="false"}
                        },
                        Email=request.Email_Id,
                        FirstName=request.GuestFirstName,
                        Gender=Gender.Male,
                        KnownTravelerNumber="789456",
                        LastName=request.GuestLastName,
                        PassengerType=PassengerType.Adult,
                        PhoneNumber=request.MobileNum,
                        UserName="rsarda@tavisca.com"
                    }
                },
                    Payments = new CreditCardPayment[]
                   {
                       new CreditCardPayment()
                    {
                        PaymentType=PaymentType.Credit,
                        Amount=new Money()
                        {
                                Amount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount,
                                Currency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency,
                                DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount,
                                DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency
                        },
                        Attributes=new StateBag[]
                        {
                            new StateBag() { Name="API_SESSION_ID", Value=request.SessionId},
                            new StateBag(){ Name="PointOfSaleRule"},
                            new StateBag(){ Name="SectorRule"},
                            new StateBag(){ Name="_AttributeRule_Rovia_Username"},
                            new StateBag(){ Name="_AttributeRule_Rovia_Password"},
                        },
                        BillingAddress=new Address()
                        {
                            CodeContext=LocationCodeContext.Address,
                            AddressLine1="E Sunset Rd",
                            AddressLine2="Near Trade Center",
                            City=new City()
                            {
                                CodeContext=LocationCodeContext.City,
                                Name="LAS",
                                Country="US",
                                State="State",
                            },
                            PhoneNumber="123456",
                            ZipCode="123456"
                        } ,
                        CardMake=new CreditCardMake()
                        {
                            Code="VI",
                            Name="VISA"
                        },
                        CardType=CreditCardType.Personal,
                        ExpiryMonthYear=DateTime.Parse("2020-12-01T00:00:00"),
                        IsThreeDAuthorizeRequired=false,
                        NameOnCard="test card",
                        Number="0000000000001111",
                        SecurityCode="123"
                    }
                   },
                    Products = new HotelTripProduct[]
                {
                   new HotelTripProduct()
                   {
                       Attributes=new StateBag[]
                       {
                           new StateBag{ Name ="API_SESSION_ID", Value=request.SessionId},
                           new StateBag{ Name ="token", Value=""},
                           new StateBag{ Name ="ChargingHoursPriorToCPW", Value="48"},
                           new StateBag{ Name ="IsLoginWhileSearching", Value="Y"},
                           new StateBag{ Name ="IsInsuranceSelected", Value="no"},
                       },
                       Id=Guid.NewGuid(),
                       IsOnlyLeadPaxInfoRequired=true,
                       Owner=new User()
                       {
                           AdditionalInfo=new StateBag[]
                           {
                               new StateBag(){Name="AgencyName", Value="WV"},
                               new StateBag(){ Name="CompanyName", Value="Rovia"},
                               new StateBag(){ Name="UserType", Value="Normal"}
                           },
                            Email = "sbejugam@v-worldventures.com",
                            FirstName = "Sandbox",
                            LastName = "Test",
                            MiddleName = "User",
                            Prefix = "Mr.",
                            Title = "Mr",
                            UserId = 169050,
                            UserName = "3285301"
                       },
                       PassengerSegments=new PassengerSegment[]
                       {
                           new PassengerSegment()
                           {
                               BookingStatus=TripProductStatus.Planned,
                               PostBookingStatus=PostBookingTripStatus.None,
                               Rph=4
                           }
                       },
                       PaymentBreakups=new PaymentBreakup[]
                       {
                           new PaymentBreakup()
                           {
                               Amount=new Money()
                               {
                                   Amount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount,
                                Currency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency,
                                DisplayAmount = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount,
                                DisplayCurrency = itinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency
                               }
                           }
                       },
                       PaymentOptions=new PaymentType[]
                       {
                           PaymentType.SoftCash,
                           PaymentType.External,
                           PaymentType.Credit
                       },
                       Rph=4,
                       CancellationDetails=new CancellationDetails()
                       {
                          AppliedRule=new HotelCancellationRule()
                          {

                          }
                       },
                       HotelItinerary=itinerary,
                       HotelSearchCriterion=criterion,
                       RoomOccupancyTypes=new RoomOccupancyType[]
                       {
                           new RoomOccupancyType()
                           {
                               PaxQuantities=new PassengerTypeQuantity[]
                               {
                                   new PassengerTypeQuantity()
                                   {
                                       Ages=criterion.Guests[0].Ages,
                                       PassengerType=PassengerType.Adult,
                                       Quantity=criterion.Guests[0].Quantity
                                   }
                               }
                           }
                       }
                   }
                },

                    Status = TripStatus.Planned,
                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 4 }
                }

            };

            //tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            return tripFolderBookRQ;
        }

        private HotelEngienSearch.HotelSearchCriterion GetCachedCriterion(string sessionId)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = new HotelEngienSearch.HotelSearchCriterion();
            if (hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterion = hotelSearchCriterionCache.FetchCriterion(sessionId);
            }
            return hotelSearchCriterion;
        }

        private HotelEngienSearch.HotelItinerary GetCachedItinerary(string sessionId)
        {
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            HotelEngienSearch.HotelItinerary hotelItinerary = new HotelEngienSearch.HotelItinerary();
            if (singleAvailCache.CheckIfPresent(sessionId))
            {
                hotelItinerary = singleAvailCache.FetchItinerary(sessionId);
            }
            return hotelItinerary;
        }
    }
}