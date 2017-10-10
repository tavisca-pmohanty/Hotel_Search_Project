﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchRequest
{
    public class HotelSearchRq
    {
        public HotelSuggestionRS SelectedHotel { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string Rooms { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
    }
}