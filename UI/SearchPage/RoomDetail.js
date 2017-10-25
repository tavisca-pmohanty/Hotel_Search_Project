
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.length;i++)
       {
    
             if(roomItinerary[i].SupplierName=="HotelBeds Test")
          {
              typeOfRooms.push({
                image:roomItinerary[i].ImageUrl,
                roomType:roomItinerary[i].RoomName,
                roomDescription:roomItinerary[i].RoomDescription,
                roomFare:roomItinerary[i].CurrencyType+" "+roomItinerary[i].Price,
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
                                     url: "http://localhost:49898/index/HotelListing/search/GetRoomPricing",
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



  