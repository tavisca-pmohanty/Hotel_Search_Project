
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.Itinerary.Rooms.length;i++)
       {
    
            typeOfRooms.push({
                image:roomItinerary.Itinerary.HotelProperty.MediaContent[0].Url,
               roomType:roomItinerary.Itinerary.Rooms[i].RoomName,
                roomDescription:roomItinerary.Itinerary.Rooms[i].RoomDescription,
                roomFare:"Rs."+roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.Amount,
            });
        }

var template = $('#room-items');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(typeOfRooms);

  $('#roomList-container').html(html);

$(".room-button").click(function()
                       {
    var roomName=this.value;
    var numOfRooms=roomItinerary.HotelCriterionData.NoOfRooms;
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
                                     url: "http://localhost:52363/index/HotelListing/search/GetRoomPricing",
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
            function getSuccess(dynamicPricingData)
                    {
                      var dynamicPricing;
                      if(dynamicPricingData.Itinerary==null)
                      {
                         alert("Cannot connect to the server at this moment to get the updated price.Please try again later or select some other room");
                         return;
                      }
                      else
                      {
                        dynamicPricing={
                              data:dynamicDataPricing,
                              sessionId:roomItinerary.sessionId,
                              roomSelected:roomName,
                              rooms:numOfRooms
                         }
                      }
                        
                        sessionStorage.setItem('UpdatedRoomListing',JSON.stringify(dynamicPricing));
			                  window.location="guest-details.html";
                    }
                });      
});



  