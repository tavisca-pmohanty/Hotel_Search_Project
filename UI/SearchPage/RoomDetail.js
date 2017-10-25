
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.length;i++)
       {
             //if(roomItinerary[i].SupplierName=="HotelBeds Test"|| roomItinerary.SupplierName=="TouricoTGSTest")
         //{ 
               typeOfRooms.push({
                image:roomItinerary[i].ImageUrl,
                roomType:roomItinerary[i].RoomName,
                roomDescription:roomItinerary[i].RoomDescription,
                roomFare:roomItinerary[i].CurrencyType+" "+roomItinerary[i].Price,
                latitude:roomItinerary[i].Latitude,
                longitude:roomItinerary[i].Longitude
            });
        // }
      }

var template = $('#room-item');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(typeOfRooms);

  $('#roomlist-container').html(html);



$(".room-button").click(function()
                       {
    var roomName=this.value;
    var pricingRequest={
                    sessionId:roomItinerary[0].SessionId,
                    roomName:roomName
    }
    var numOfRooms=roomItinerary.NoOfRooms;
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
                      if(dynamicPricingData==null)
                      {
                         alert("Cannot connect to the server at this moment to get the updated price.Please try again later or select some other room");
                         return;
                      }
                      else
                      {
                        
                      }
                        
                        sessionStorage.setItem('UpdatedRoomListing',JSON.stringify(dynamicPricingData));
                        window.location="guest-details.html";
                    }
                });      
});



  