using HotelSearchEngine;
using System;
using System.Threading.Tasks;
using TripEngineServices;

namespace hotelsearchengine
{
    public class Tripfolderbookrqparser
    {
        public async Task<TripFolderBookRS>Get()
        {
            HotelSearchR hotelSearchRepository = new HotelSearchR();
            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                SessionId = hotelSearchRepository.SessionId,
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[1]
                    {
                        0
                    }
                },
                ResultRequested = ResponseType.Unknown,
                //AdditionalInfo = new StateBag[] 
                //{

                //}
                TripFolder = new TripFolder()
                {
                    CreatedDate = new DateTime(0001, 01, 01),
                    Creator = new User()
                    {
                        Email = "sshrikhande@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "sshrikhande",
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    LastModifiedDate = new DateTime(),
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
                        PosId = 101,
                        Requester = new Company()
                        {
                            DK = "200000D",
                            ID = 0,
                            CodeContext = CompanyCodeContext.HotelChain,

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
                            PassengerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            PassengerType = PassengerType.Adult,
                            PhoneNumber = "123456789",
                            Rph = 0,
                            UserId = 0,
                            UserName = "sshrikhande@tavisca.com"
                        }
                    },
                    Payments = new CreditCardPayment[]
                    {
                         new CreditCardPayment()
                         {

                            CardMake = new CreditCardMake()
                            {
                                Code = "VI",
                                Name = "Visa"
                            },
                            CardType = CreditCardType.Personal,
                            ExpiryMonthYear = new DateTime(2019, 01, 01),
                            NameOnCard = "Saurabh Cache",
                            IsThreeDAuthorizeRequired = false,
                            Number = "0000000000001111",
                            SecurityCode = "123",
                            Amount =//TripProductPriceCache.Cache[sessionId].TripProduct.
                            new Money()
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
                                    Code = "PLN",
                                    CodeContext = LocationCodeContext.City,
                                    Name = "Plano",
                                    Country = "US",
                                    State = "TX"

                                }
                            },
                            


                           
                         }

                    },
                    Products = new TripProduct[] { hotelSearchRepository.TripDetails },
                },
            };
            
            tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            var response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            return response;
        }
    }
}