using AutoComplete.Model;
using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEngienSearch
{
    public class HotelSearchRq:IRequest
    {
        public HotelSuggestionRS SelectedHotel { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string Rooms { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
    }
}