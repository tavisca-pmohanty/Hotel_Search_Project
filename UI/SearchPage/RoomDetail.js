
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.Itinerary.Rooms.length;i++)
       {
    
             if(roomItinerary.Itinerary.Rooms[i].HotelFareSource.Name=="HotelBeds Test")
          {
              typeOfRooms.push({
                //name:roomItinerary.itinerary.HotelProperty.Name,
                image:roomItinerary.Itinerary.HotelProperty.MediaContent[0].Url,
                roomType:roomItinerary.Itinerary.Rooms[i].RoomName,
                roomDescription:roomItinerary.Itinerary.Rooms[i].RoomDescription,
                roomFare:roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.BaseEquivCurrency+" "+roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.UsdEquivAmount,
            });
          }
        }

var template = $('#room-item');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(typeOfRooms);

  $('#roomlist-container').html(html);



$(".room-button").click(function()
                       {
    var roomName=this.value;
    var pricingRequest={
                    SessionId:roomItinerary.SessionId,
                    Itinerary:roomItinerary.Itinerary,
                    HotelCriterionData:roomItinerary.HotelCriterionData,
                    RoomName:roomName
    }
    var numOfRooms=roomItinerary.HotelCriterionData.NoOfRooms;
    var data=JSON.stringify(pricingRequest);
                    try
                          {
                                 $.ajax({
                                    headers: 
                                    { 
                                        'Accept': 'application/json',
                                        'Content-Type': 'application/json' 
                                    },
                                     type: "POST",
                                     url: "http://localhost:56883/index/HotelListing/search/GetRoomPricing",
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
                      if(dynamicPricingData.TripDetails==null)
                      {
                         alert("Cannot connect to the server at this moment to get the updated price.Please try again later or select some other room");
                         return;
                      }
                      else
                      {
                        dynamicPricing={
                              data:dynamicPricingData.TripDetails,
                              sessionId:dynamicPricingData.SessionId,
                              rooms:numOfRooms
                         }
                      }
                        
                        sessionStorage.setItem('UpdatedRoomListing',JSON.stringify(dynamicPricing));
                        window.location="guest-details.html";
                    }
                });      
});



  