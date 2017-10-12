using System;
using System.Threading.Tasks;

namespace BookTripFolder
{
    public class Trip
    {
        public async Task<TripFolderBookRQ> Get()
        {
            TripFolderBookRQ tripFolderBookRQ =new TripFolderBookRQ()
            {
                ResultRequested = ResponseType.Unknown,
                TripFolder = new TripFolder()
                {
                    Creator = new User()
                    {
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "sshrikhande",
                    Owner = new User()
                    {
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    Pos = new PointOfSale()
                    {
                        PosId = 101,
                        Requester = new Company()
                        {
                            DK = "200000D",
                            ID = 0
                        }
                    },
                    Type = TripFolderType.Personal,
                    Passengers = new Passenger[]
                    {
                        new Passenger()
                        {
                            Age = 27,
                            BirthDate = new DateTime(1990,03,03),
                            Email = "shrikhande@tavisca.com",
                            FirstName = "Shweta",
                            Gender = Gender.Male,
                            LastName = "Shrikhande",
                            PassengerType = PassengerType.Adult,
                            Rph = 0,
                        }
                    },
                    Payments = new Payment[]
                    {
                        new Payment()
                        {
                            Amount = new Money()
                            {
                                Amount = 200.34M,
                                Currency = "USD",
                                DisplayAmount = 200.34M,
                                DisplayCurrency = "USD"
                            },
                            BillingAddress = new Address()
                            {
                                CodeContext = LocationCodeContext.Address,
                                AddressLine1 = "5100 Tennyson Parkway",
                                AddressLine2 = "dsv effs",
                                PhoneNumber = "972-805-5200",
                                ZipCode = "75024",
                                City = new City()
                                {
                                    CodeContext = LocationCodeContext.City,
                                    Name = "Plano",
                                    Country = "US",
                                    State = "TX"

                                }
                            },
                        }
                    },
                    Products = new TripProduct[]
                    {
                        new TripProduct()
                        {
                            LeadPassengerRph = 0,
                            Owner = new User()
                            {
                                FirstName = "Shweta",
                                LastName = "Shrikhande",
                                UserId = 26149061229281280,
                                UserName = "sshrikhande"
                            },
                            PassengerSegments = new PassengerSegment[]
                            {
                                new PassengerSegment()
                                {
                                    PassengerRph = 0,
                                    Rph = 0
                                }
                            },
                            PaymentBreakups = new PaymentBreakup[]
                            {
                                new PaymentBreakup()
                                {
                                    Amount = new Money()
                                    {
                                        Amount = 200.34M,
                                        Currency = "USD",
                                        DisplayAmount = 200.34M,
                                        DisplayCurrency = "USD"
                                    },
                                    PassengerRph = 0,
                                    PaymentRph = 0,
                                }
                            },
                            PaymentOptions = new PaymentType[]
                            {
                                PaymentType.External,
                                PaymentType.SoftCash,
                                PaymentType.Credit
                            },
                            Rph = 0,
                            //hotel
                            //hotelSearchCriterion 
                        },

                    },



                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 0 }
                }

            };
          // HotelItinerary hotelItinerary = new HotelItinerary()
            //{

            //};
            //HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion()
            //{

            //};
            //RoomOccupancyType roomOccupancyType = new RoomOccupancyType()
            //{

            //};
            return tripFolderBookRQ;
        }
        public async Task<TripFolderBookRS> GetResponse(TripFolderBookRQ tripFolderBookRQ)
        {
            TripsEngineClient client = new TripsEngineClient();
            TripFolderBookRS rq=await client.BookTripFolderAsync(tripFolderBookRQ);
            return rq;
        }
    }
}

