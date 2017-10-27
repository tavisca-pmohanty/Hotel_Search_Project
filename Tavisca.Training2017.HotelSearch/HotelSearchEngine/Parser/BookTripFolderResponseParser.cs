using APITripEngine;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Parser
{
    public class BookTripFolderResponseParser
    {
        BookTripFolderResponse bookTripFolderResponse;
        public BookTripFolderResponseParser()
        {
            bookTripFolderResponse = new BookTripFolderResponse();
        }
        public async Task<BookTripFolderResponse> ParserAsync(TripFolderBookRS tripFolderBookRQ)
        {
            bookTripFolderResponse.SessionId = tripFolderBookRQ.SessionId;
            return bookTripFolderResponse;
        }
    }
}
