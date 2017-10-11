
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.Itinerary.Rooms.length;i++)
       {
            typeOfRooms.push({
                image:roomItinerary.Itinerary.HotelProperty.MediaContent[0].url,
               roomType:roomItinerary.Itinerary.Rooms[i].RoomName,
              
                roomDescription:roomItinerary.Itinerary.Rooms[i].RoomDescription,
//                bedType:roomItinerary.Itinerary.Rooms[i].BedType,
                roomFare:"Rs."+roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.Amount,
            });
        }

var template = $('#room-items');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(typeOfRooms);

  $('#roomList-container').html(html);

$("#room-button").click(function()
                       {
    var roomName=this.value;
    var data=JSON.stringify(roomItinerary);
                    try
                          {
                                 $.ajax({
                                    headers: 
                                    { 
                                        'Accept': 'application/json',
                                        'Content-Type': 'application/json' 
                                    },
                                     type: "POST",
                                     url: "http://localhost:51052/index/HotelListing/search/GetRoomPricing",
                                     cache: false,
                                     data:JSON.stringify(data),
                                     dataType: 'json',
                                    
                                     success: getSuccess,
                                     crossDomain:true,
                                 });
                          } 
                        catch (e)
                         {
                                alert(e);
                         }
            function getSuccess(data)
                    {
                        var obj=JSON.parse(data);
                        sessionStorage.setItem('HotelListing',JSON.stringify(obj));
			            window.location="Guest-Details.html";
                    }
                });      
});



  