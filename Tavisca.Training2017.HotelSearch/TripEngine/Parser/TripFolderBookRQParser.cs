﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripEngine.Models;
using TripEngineServices;

namespace TripEngine
{
    public class TripFolderBookRQparser
    {
       
        public async Task<TripFolderBookRQ> ParserAsync(HotelSearchBookingRequest request)
        {
            List<HotelCancellationRule> cancellationRuleList = new List<HotelCancellationRule>();
            HotelItinerary itinerary = request.TripDetails.HotelItinerary;
            itinerary.HotelCancellationPolicy.CancellationRules = new HotelCancellationRule[]
            {
                new HotelCancellationRule(),
            };
            itinerary.HotelCancellationPolicy.CancellationRules = cancellationRuleList.ToArray();
            HotelSearchCriterion criterion = request.TripDetails.HotelSearchCriterion;
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
                        Email="rsarda@tavisca.com",
                        FirstName="Sandbox",
                        Gender=Gender.Male,
                        KnownTravelerNumber="789456",
                        LastName="Test",
                        PassengerType=PassengerType.Adult,
                        PhoneNumber="1111111111",
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
                                Amount = request.TripDetails.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.BaseEquivAmount,
                                Currency = "USD",
                                DisplayAmount = request.TripDetails.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.BaseEquivAmount,
                                DisplayCurrency = "USD"
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
                                    Amount = request.TripDetails.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.BaseEquivAmount,
                                    Currency = "USD",
                                    DisplayAmount = request.TripDetails.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.BaseEquivAmount,
                                    DisplayCurrency = "USD"
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
    }
}