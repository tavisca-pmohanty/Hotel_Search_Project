using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Parser
{
    public class BookTripFolderResponseParser:IParser
    {
        BookTripFolderResponse bookTripFolderResponse;
        public BookTripFolderResponseParser()
        {
            bookTripFolderResponse = new BookTripFolderResponse();
        }
        public async Task<IResponse> ParserAsync(IRequest request)
        {
            TripFolderBookRS tripFolderBookRQ = (TripFolderBookRS)request;
            bookTripFolderResponse.SessionId = tripFolderBookRQ.SessionId;
            return bookTripFolderResponse;
        }
    }
}
