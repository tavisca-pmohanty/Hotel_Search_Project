//using System;
//using System.Collections.Generic;
//using System.Text;
//using TripEngineServices;
//using HotelSearchEngine;

//namespace HotelSearchEngine
//{
//    public class TripFolderBookRQParser
//    {


//        public TripFolderBookRQ Parse(HotelSearchRQ hotelBookingRQ)
//        {
//            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
//            {
//                ResultRequested = ResponseType.Unknown,
//                TripFolder = new TripFolder()
//                {
//                    Creator = new User()
//                    {
//                        FirstName = "Shweta",
//                        LastName = "Shrikhande",
//                        UserId = 26149061229281280,
//                        UserName = "sshrikhande"
//                    },
//                    FolderName = "sshrikhande",
//                    Owner = new User()
//                    {
//                        FirstName = "Shweta",
//                        LastName = "Shrikhande",
//                        UserId = 26149061229281280,
//                        UserName = "sshrikhande"
//                    },
//                    Pos = new PointOfSale()
//                    {
//                        PosId = 101,
//                        Requester = new Company()
//                        {
//                            DK = "200000D",
//                            ID = 0
//                        }
//                    },
//                    Type = TripFolderType.Personal,
//                    Passengers = new Passenger[]
//                    {
//                        new Passenger()
//                        {
//                            Age = 27,
//                            BirthDate = new DateTime(1990,03,03),
//                            Email =hotelBookingRQ.EmailId,
//                            FirstName = hotelBookingRQ.GuestFirstName,
//                            Gender = Gender.Male,
//                            LastName = hotelBookingRQ.GuestLastName,
//                            PassengerType = PassengerType.Adult,
//                            Rph = 0,
//                        }
//                    },
//                    Payments = new Payment[]
//                    {
//                        new Payment()
//                        {
//                            Amount = new Money()
//                            {
//                                Amount = 200.34M,
//                                Currency = "USD",
//                                DisplayAmount = 200.34M,
//                                DisplayCurrency = "USD"
//                            },
//                            BillingAddress = new Address()
//                            {
//                                CodeContext = LocationCodeContext.Address,
//                                AddressLine1 = "5100 Tennyson Parkway",
//                                AddressLine2 = "dsv effs",
//                                PhoneNumber = "972-805-5200",
//                                ZipCode = "75024",
//                                City = new City()
//                                {
//                                    CodeContext = LocationCodeContext.City,
//                                    Name = "Plano",
//                                    Country = "US",
//                                    State = "TX"

//                                }
//                            },
//                        }
//                    },
//                    Products = new TripProduct[]
//                    {
//                        new HotelTripProduct()
//                        {
//                            LeadPassengerRph = 0,
//                            Owner = new User()
//                            {
//                                FirstName = "Shweta",
//                                LastName = "Shrikhande",
//                                UserId = 26149061229281280,
//                                UserName = "sshrikhande"
//                            },
//                            PassengerSegments = new PassengerSegment[]
//                            {
//                                new PassengerSegment()
//                                {
//                                    PassengerRph = 0,
//                                    Rph = 0
//                                }
//                            },
//                            PaymentBreakups = new PaymentBreakup[]
//                            {
//                                new PaymentBreakup()
//                                {
//                                    Amount = new Money()
//                                    {
//                                        Amount = 200.34M,
//                                        Currency = "USD",
//                                        DisplayAmount = 200.34M,
//                                        DisplayCurrency = "USD"
//                                    },
//                                    PassengerRph = 0,
//                                    PaymentRph = 0,
//                                }
//                            },
//                            PaymentOptions = new PaymentType[]
//                            {
//                                PaymentType.External,
//                                PaymentType.SoftCash,
//                                PaymentType.Credit
//                            },
//                            Rph = 0,
//                            HotelItinerary = new HotelItinerary()
//                            {
//                                Id = new Guid(),
//                                ItineraryStatus = ItineraryStatusType.Unbooked,
//                                Rph = 0,
//                                AllPaxDetailsRequired = true,
//                                Deals = new Deal[]
//                                {
//                                    new DiscountDeal()
//                                    {
//                                        DealStatus = DealStatus.Active,
//                                        DealType = "DiscountDeal",
//                                        EndDate = new DateTime(2017,12,12),
//                                        IsPackageOnly = false,
//                                        LongDescription = "25%",
//                                        UsageEndDate = new DateTime(0001,01,01),
//                                        UsageStartDate = new DateTime(0001,01,01),
//                                        RoomIds = new Guid[]
//                                        {
//                                            new Guid("f7c55ac1-b9c5-4d74-8eee-8b52353813c7")
//                                        },
//                                        Rph = 0,
//                                        StartDate = new DateTime(2017,12,11),
//                                        Title = "Save 25%",
//                                        Amount = new Money()
//                                        {
//                                            Amount = 59.67M,
//                                            BaseEquivAmount = 53.67M,
//                                            BaseEquivCurrency = "USD",
//                                            DisplayAmount = 59.67M,
//                                            DisplayCurrency = "USD",
//                                            UsdEquivAmount = 59.67M
//                                        },
//                                        ApplyOn ="BaseFare"
//                                    }

//                                },
//                                Fare = new HotelFare()
//                                {
//                                    BaseFare = new BaseFare()
//                                    {
//                                        Amount = 137.27M,
//                                        BaseEquivAmount = 0,
//                                        Currency = "USD",
//                                        UsdEquivAmount = 137.27M
//                                    },
//                                    FareType = FareType.Negotiated,
//                                    Id = 0,
//                                    Rph = 0,
//                                    TotalCommission = new Commission()
//                                    {
//                                        Amount = 0,
//                                        BaseEquivAmount = 0,
//                                        Currency = "USD",
//                                        DisplayAmount = 0,
//                                        DisplayCurrency = "USD",
//                                        UsdEquivAmount = 0
//                                    }
//                                },
//                            },
//                            HotelSearchCriterion = new HotelSearchCriterion(),
//                            RoomOccupancyTypes = new RoomOccupancyType[]
//                            {
//                                new RoomOccupancyType()
//                                {
//                                    PaxQuantities = new PassengerTypeQuantity[]
//                                    {
//                                        new PassengerTypeQuantity()
//                                        {


//                                        }
//                                    }
//                                }
//                            }

//                        },

//                    },



//                },
//                TripProcessingInfo = new TripProcessingInfo()
//                {
//                    TripProductRphs = new int[] { 0 }
//                }

//            };
//            return null;
//        }
        

//    }
//}
