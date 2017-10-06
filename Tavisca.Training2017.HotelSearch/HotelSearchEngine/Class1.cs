using System;
using tavisca.com;

namespace HotelSearchEngine
{
    public class Class1
    {
        public  async void Func()
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelSearchRQ rq = new HotelSearchRQ();
            rq.ResultRequested = ResponseType.Complete;
            rq.SessionId = Guid.NewGuid().ToString();
            AvailabilityFilter availF = new AvailabilityFilter();
            availF.ReturnOnlyAvailableItineraries = true;
            rq.Filters = new HotelFilter[1] { availF };
            HotelSearchCriterion criteria = new HotelSearchCriterion();
            StateBag[] bag = new StateBag[5];
            //StateBag bag1 = new StateBag() { Name = "API_SESSION_ID", Value = "bf453bd0-8de8-417c-bccf-c6b8d50d6ad6" };
            StateBag bag2 = new StateBag() { Name = "FareType", Value = "BaseFare" };
            StateBag bag3 = new StateBag() { Name = "ResetFiltersIfNoResults", Value = "true" };
            StateBag bag4 = new StateBag() { Name = "ReturnRestrictedRelevanceProperties", Value = "true" };
            StateBag bag5 = new StateBag() { Name = "MaxHideawayRelevancePropertiesToDisplay", Value = "5" };
            StateBag bag6 = new StateBag() { Name = "MaxHotelRelevancePropertiesToDisplay", Value = "10" };
            //bag[0] = bag1;
            bag[1] = bag2;
            bag[2] = bag3;
            bag[3] = bag4;
            bag[4] = bag5;
            bag[0] = bag6;
            criteria.Attributes = bag;
            criteria.MatrixResults = true;
            criteria.MaximumResults = 1500;
            PointOfSale newPos = new PointOfSale();
            StateBag[] newBag = new StateBag[11];
            newBag[0] = new StateBag() { Name = "IPAddress", Value = "127.0.0.1" };
            newBag[1] = new StateBag() { Name = "DealerUrl", Value = "localhost" };
            newBag[2] = new StateBag() { Name = "SiteUrl", Value = "ota" };
            newBag[3] = new StateBag() { Name = "AccountId", Value = "169050" };
            newBag[4] = new StateBag() { Name = "UserId", Value = "3285301" };
            newBag[5] = new StateBag() { Name = "CountryName", Value = "United States" };
            newBag[6] = new StateBag() { Name = "CountryCode", Value = "US" };
            newBag[7] = new StateBag() { Name = "UserProfileCountryCode", Value = "US" };
            newBag[8] = new StateBag() { Name = "CustomerType", Value = "DTP" };
            newBag[9] = new StateBag() { Name = "DKCommissionIdentifier", Value = "3285301P" };
            newBag[10] = new StateBag() { Name = "MemberSignUpDate", Value = "Tue, 04 Jan 2011" };
            newPos.AdditionalInfo = newBag;
            newPos.PosId = 101;
            criteria.Pos = newPos;
            Company company = new Company();
            Agency agency = new Agency();
            Address address = new Address();
            address.CodeContext = LocationCodeContext.Address;
            address.GmtOffsetMinutes = 0;
            address.Id = 0;
            address.AddressLine1 = "Test 1";
            address.AddressLine2 = "Test 2";
            City city = new City();
            city.CodeContext = LocationCodeContext.City;
            city.GmtOffsetMinutes = 0;
            city.Id = 0;
            //city.Name = "Pune";
            //city.Country = "IND";
            //city.State = "MH";
            address.City = city;
            agency.AgencyId = 0;
            agency.AgencyName = "WV";
            company.Code = "DTP";
            company.CodeContext = CompanyCodeContext.PersonalTravelClient;
            company.DK = "3285301P";
            company.FullName = "Rovia";
            company.ID = 0;
            newPos.Requester = company;
            criteria.PriceCurrencyCode = "INR";
            PassengerTypeQuantity[] guests = new PassengerTypeQuantity[1]
            {
                new PassengerTypeQuantity()
                {
                    Ages = new int[2]
                    {
                        30,30
                    },
                    PassengerType = PassengerType.Adult,
                    Quantity = 2
                }
            };
            criteria.Guests = guests;
            Location loc = new Location();
            loc.CodeContext = LocationCodeContext.GeoCode;
            loc.GeoCode = new GeoCode() { Latitude = 29.4220145247296f, Longitude = -98.4841268452301f };
            loc.GmtOffsetMinutes = 0;
            loc.Id = 0;
            //loc.Name = "Taj Mahal";
            loc.Radius = new Distance() { Amount = 30, From = LocationCodeContext.City, Unit = DistanceUnit.mi };
            criteria.Location = loc;
            criteria.NoOfRooms = 1;
            HotelSearchProcessingInfo pInfo = new HotelSearchProcessingInfo();
            pInfo.DisplayOrder = HotelDisplayOrder.ByRelevanceScoreDescending;
            criteria.ProcessingInfo = pInfo;
            RoomOccupancyType[] type = new RoomOccupancyType[1]
            {
                new RoomOccupancyType()
                {
                    PaxQuantities = guests
                }
            };
            criteria.RoomOccupancyTypes = type;
            criteria.SearchType = HotelSearchType.City;
            DateTimeSpan span = new DateTimeSpan();
            span.Duration = 0;
            span.End = DateTime.Parse("2017-10-26");
            span.Start = DateTime.Parse("2017-10-25");
            criteria.StayPeriod = span;
            PagingInfo info = new PagingInfo()
            {
                Enabled = true,
                EndNumber = 120,
                StartNumber = 100,
                TotalRecordsBeforeFiltering = 0,
                TotalResults = 0
            };
            rq.PagingInfo = info;
            rq.HotelSearchCriterion = criteria;
            var response = await client.HotelAvailAsync(rq);
            foreach (HotelItinerary hotel in response.Itineraries)
            {
                Console.WriteLine(hotel.HotelProperty.Name);
            }
            Console.ReadKey();
        }
    }
}
