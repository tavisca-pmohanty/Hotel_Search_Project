using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HotelSearchEngine
{
    class HotelRequestParser
    {
        private readonly bool _AvailableItineraries = true;
        private readonly int _maxResults = 1500;
        private readonly bool _matrixResults = true;
        private readonly int _defaultPosId = 101;
        private readonly LocationCodeContext _defaultLocationCodeContext = LocationCodeContext.Address;
        private readonly int _deafaultGmtOffsetMinutes = 0;
        private readonly int _defaultAddressId = 0;
        private readonly string _defaultAddressLine1 = "Test 1";
        private readonly string _defaultAddressLine2 = "Test 2";
        private readonly string _defaultAgencyName = "WV";
        private readonly string _defaultCompanyCode = "DTP";
        private readonly CompanyCodeContext _defaultCompanyCodeContext = CompanyCodeContext.PersonalTravelClient;
        private readonly string _defaultCompanyDk = "3285301P";
        private readonly string _defaultCompanyName = "ROVIA";
        private readonly int _defaultCompanyId = 0;
        private readonly string _defaultPriceCurrencyCode = "USD";
        private readonly float _deafultSearchRadius = 30;
        private readonly Dictionary<string, LocationCodeContext> _locationTypeResolveDictionary = new Dictionary<string, LocationCodeContext>()
        {
            {"Address",LocationCodeContext.Address },
            {"Airport",LocationCodeContext.Airport },
            {"City",LocationCodeContext.City },
            {"GeoCode",LocationCodeContext.GeoCode },
            {"PointOfInterest",LocationCodeContext.PointOfInterest},
            {"RentalLocation",LocationCodeContext.RentalLocation },
            {"ZipCode", LocationCodeContext.ZipCode },
             {"Hotel", LocationCodeContext.GeoCode }
        };
        private readonly Dictionary<string, HotelSearchType> _hotelSearchTypeResolveDictionary = new Dictionary<string, HotelSearchType>()
        {
            {"Address",HotelSearchType.Address },
            {"Airport",HotelSearchType.Airport },
            {"City",HotelSearchType.City },
            {"GeoCode",HotelSearchType.GeoCode },
            {"PointOfInterest",HotelSearchType.PointOfInterest},
            {"ZipCode", HotelSearchType.ZipCode },
            {"IdList",HotelSearchType.IdList },
            {"Tags",HotelSearchType.Tags },
            {"Hotel", HotelSearchType.GeoCode}
        };
        private readonly int _defaultPagingInfoStartNumber = 100;
        private readonly int _defaultPagingInfoEndNumber = 120;
        private readonly int _defaultTotalRecordsBeforeFiltering = 0;
        private readonly int _defaultTotalResults = 0;

        public HotelSearchRQ Parser(HotelSearchRq request)
        {

            HotelSearchRQ listingRequest = new HotelSearchRQ();
            //listingRequest.SessionId = Guid.NewGuid().ToString();
            listingRequest.ResultRequested = ResponseType.Complete;
            listingRequest.SessionId = Guid.NewGuid().ToString();
            listingRequest.Filters = new AvailabilityFilter[1]
           {
                new AvailabilityFilter()
                {
                    ReturnOnlyAvailableItineraries = _AvailableItineraries
                }
           };
            float longitude;
            float.TryParse(request.SelectedHotel.Longitude, out longitude);
            float latitude;
            float.TryParse(request.SelectedHotel.Latitude, out latitude);
            GeoCoordinates geocode = new GeoCoordinates(longitude, latitude);
            listingRequest.HotelSearchCriterion = new HotelSearchCriterion();
            listingRequest.HotelSearchCriterion.MatrixResults = _matrixResults;
            listingRequest.HotelSearchCriterion.MaximumResults = _maxResults;
            listingRequest.HotelSearchCriterion.Pos = new PointOfSale();
            listingRequest.HotelSearchCriterion.Pos.PosId = _defaultPosId;
            listingRequest.HotelSearchCriterion.Pos.Requester = GetDefaultRequester();
            listingRequest.HotelSearchCriterion.PriceCurrencyCode = _defaultPriceCurrencyCode;
            listingRequest.HotelSearchCriterion.Guests = GetGuestDetails(request.Adults, request.Children);
            listingRequest.HotelSearchCriterion.Location = GetLocation(request.SelectedHotel.CityName, request.SelectedHotel.SearchType, geocode);
            listingRequest.HotelSearchCriterion.NoOfRooms = GetMinimumRoomsRequired(request.Adults, request.Children);
            listingRequest.HotelSearchCriterion.ProcessingInfo = new HotelSearchProcessingInfo()
            {
                DisplayOrder = HotelDisplayOrder.ByRelevanceScoreDescending
            };
            listingRequest.HotelSearchCriterion.RoomOccupancyTypes = new RoomOccupancyType[1]
            {
                new RoomOccupancyType()
                {
                    PaxQuantities = listingRequest.HotelSearchCriterion.Guests
                }
            };
            listingRequest.HotelSearchCriterion.SearchType = _hotelSearchTypeResolveDictionary[request.SelectedHotel.SearchType];
            listingRequest.HotelSearchCriterion.StayPeriod = GetStayPeriod(request.InDate, request.OutDate);
            listingRequest.PagingInfo = new PagingInfo()
            {
                Enabled = true,
                StartNumber = _defaultPagingInfoStartNumber,
                EndNumber = _defaultPagingInfoEndNumber,
                TotalRecordsBeforeFiltering = _defaultTotalRecordsBeforeFiltering,
                TotalResults = _defaultTotalResults
            };
            return listingRequest;
        }
        private DateTimeSpan GetStayPeriod(DateTime checkInDate, DateTime checkOutDate)
        {
            return new DateTimeSpan()
            {
                Start = checkInDate,
                End = checkOutDate,
                Duration = 0
            };
        }

        private int GetMinimumRoomsRequired(string adultsCount, string childrenCount)
        {
            int adults = 0;
            int children = 0;
            Int32.TryParse(adultsCount, out adults);
            Int32.TryParse(childrenCount, out children);
            if (adults % 2 == 0)
            {
                return (adults / 2 + children / 2);
            }
            else
            {
                return (adults / 2 + children / 2) + 1;
            }
        }

        private Location GetLocation(string name, string type, GeoCoordinates geoCode)
        {
            var json = JsonConvert.SerializeObject(geoCode);
            return new Location()
            {
                CodeContext = LocationCodeContext.GeoCode,
                Radius = new Distance()
                {
                    Amount = _deafultSearchRadius,
                    From = LocationCodeContext.GeoCode,
                    Unit = DistanceUnit.mi
                },
                GeoCode = JsonConvert.DeserializeObject<GeoCode>(json)
            };
        }

        private PassengerTypeQuantity[] GetGuestDetails(string adultsCount, string childrenCount)
        {
            int adultNum = 0, childrenNum = 0;
            Int32.TryParse(adultsCount, out adultNum);
            Int32.TryParse(childrenCount, out childrenNum);
            PassengerTypeQuantity[] passengerTypeQuantity = new PassengerTypeQuantity[2];
            PassengerTypeQuantity adultPassengers = new PassengerTypeQuantity();
            adultPassengers.PassengerType = PassengerType.Adult;
            adultPassengers.Quantity = adultNum;
            adultPassengers.Ages = new int[adultNum];
            for(int i=0;i<adultPassengers.Ages.Length;i++)
            {
                adultPassengers.Ages[i] = 30;
            }
            PassengerTypeQuantity childPassengers = new PassengerTypeQuantity();
            childPassengers.PassengerType = PassengerType.Child;
            childPassengers.Ages = new int[childrenNum];
            if (childrenNum == 0)
            {
                childPassengers.Ages = new int[1];
            }
            else
            {
                childPassengers.Ages = new int[childrenNum];
            }
            for (int i = 0; i < childPassengers.Ages.Length; i++)
            {
                childPassengers.Ages[i] = 12;
            }
            childPassengers.Quantity = childrenCount.Length;
            passengerTypeQuantity[0] = adultPassengers;
            passengerTypeQuantity[1] = childPassengers;
            return passengerTypeQuantity;
        }

        private Company GetDefaultRequester()
        {
            Company company = new Company();
            Agency agency = new Agency();
            Address address = new Address();
            address.CodeContext = _defaultLocationCodeContext;
            address.GmtOffsetMinutes = _deafaultGmtOffsetMinutes;
            address.Id = _defaultAddressId;
            address.AddressLine1 = _defaultAddressLine1;
            address.AddressLine2 = _defaultAddressLine2;
            City city = new City();
            city.CodeContext = LocationCodeContext.City;
            city.GmtOffsetMinutes = _deafaultGmtOffsetMinutes;
            city.Id = _defaultAddressId;
            address.City = city;
            agency.AgencyId = 0;
            agency.AgencyName = _defaultAgencyName;
            company.Code = _defaultCompanyCode;
            company.CodeContext = _defaultCompanyCodeContext;
            company.DK = _defaultCompanyDk;
            company.FullName = _defaultCompanyName;
            company.ID = _defaultCompanyId;
            return company;
        }

    }
}