
$(document).ready(function(){
                
    
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    for(var i=0;i<roomItinerary.Itinerary.Rooms.length;i++)
        {
            typeOfRooms.push({
               roomType:roomItinerary.Itinerary.Rooms[i].RoomName,
                roomDescription:roomItinerary.Itinerary.Rooms[i].RoomDescription,
                bedType:roomItinerary.Itinerary.Rooms[i].BedType,
                roomFare:roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.Amount,
            });
        }
    var template = $('#hotel-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(hotelList);

	  $('#hotelList-container').html(html);
//    successFunction(roomItinerary);
//    
//                  });
//
//function successFunction(result)
//{
//        for(var pic of result.Itinerary.HotelProperty.MediaContent){
//        var imglink='img width=100 height=100 src='+pic.url+'"/>';
//            $("#carousel-container").append(imglink);
//   }
});

