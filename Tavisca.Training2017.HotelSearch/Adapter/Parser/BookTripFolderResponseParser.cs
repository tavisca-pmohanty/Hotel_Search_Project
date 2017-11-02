using APITripEngine;
using System.Threading.Tasks;
using HotelContract.Model;

namespace Adapter.Parser
{
    public class BookTripFolderResponseParser
    {
        BookTripFolderResponse bookTripFolderResponse;
        public BookTripFolderResponseParser()
        {
            bookTripFolderResponse = new BookTripFolderResponse();
        }
        public async Task<BookTripFolderResponse> ParserAsync(TripFolderBookRS tripFolderBookRS)
        {
            bookTripFolderResponse.SessionId = tripFolderBookRS.SessionId;
            return bookTripFolderResponse;
        }
    }
}
