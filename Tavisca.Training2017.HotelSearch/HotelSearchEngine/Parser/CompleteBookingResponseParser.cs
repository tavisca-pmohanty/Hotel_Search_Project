using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace HotelSearchEngine.Parser
{
    public class CompleteBookingResponseParser
    {
        private string _filePath = "D:\\Hotel_Search_Project\\Tavisca.Training2017.HotelSearch\\HotelSearchEngine\\BookingData\\BookingInfo.txt";
        CompleteBookingResponse completeBookingResponse;
        public CompleteBookingResponseParser()
        {
            completeBookingResponse = new CompleteBookingResponse();
        }
        public async Task<IResponse> ResponseParserAsync(CompleteBookingRS completeBookingRS)
        {
            completeBookingResponse.TransactionId = completeBookingRS.SessionId;
            HotelTripProduct product = (HotelTripProduct)completeBookingRS.TripFolder.Products[0];
            completeBookingResponse.HotelName = product.HotelItinerary.HotelProperty.Name;
            completeBookingResponse.RoomName = product.HotelItinerary.Rooms[0].RoomName;
            completeBookingResponse.CheckInDate = product.HotelItinerary.StayPeriod.Start;
            completeBookingResponse.CheckOutDate = product.HotelItinerary.StayPeriod.End;
            completeBookingResponse.NumOfNights = product.HotelItinerary.StayPeriod.Duration;
            completeBookingResponse.Status = completeBookingRS.ServiceStatus.Status.ToString();
            StoreBookingStatus(completeBookingRS.SessionId,completeBookingRS.ServiceStatus.Status.ToString());
            return completeBookingResponse;
        }

        private void StoreBookingStatus(string sessionId, string status)
        {
            BookingRecord bookingRecord = new BookingRecord();
            bookingRecord.Status = status;
            bookingRecord.BookingId = sessionId;
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(bookingRecord);
                writer = new StreamWriter(_filePath,true);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
