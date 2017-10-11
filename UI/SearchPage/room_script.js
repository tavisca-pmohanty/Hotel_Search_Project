var d = {"SelectedHotel":{"ID":"46738","HotelName":"Lohegaon Arpt","CityName":"Pune","StateCode":"","CountryCode":"IN","Latitude":"18.5791","Longitude":"73.9097","SearchType":"Airport","CulteredText":"Pune, India - Lohegaon Arpt (PNQ)"},"InDate":"2017-10-08","OutDate":"2017-10-09","Rooms":"1","Adults":1,"Children":0};



$.ajax({
  url: "http://localhost:61641/index/HotelListing/search/GetHotels",
  method:"post",
    data:JSON.stringify(d),
    contentType:"application/json",
  cache: false,
    crossDomain:"true",
    dataType:"json",
  success: successFunction
});



function successFunction(result){
    for(var hotel of result){
        for(var pic of hotel.Itinerary.HotelProperty.MediaContent){
    $("#carousel-container").append('<div class="item"><img src="'+pic.Url+'" alt="FirstPicImage" style="width:100%;"><div class="carousel-caption"><h3>Enjoy the Comfort</h3><p>Book before its Too late!</p></div></div>');
    }
}
}