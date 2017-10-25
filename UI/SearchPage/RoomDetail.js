
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.length;i++)
       {
    
<<<<<<< HEAD

       if(roomItinerary[i].SupplierName=="HotelBeds Test"|| roomItinerary.SupplierName=="TouricoTGSTest")
          {

            typeOfRooms.push({
                longitude:roomItinerary.Itinerary.HotelProperty.GeoCode.Longitude,
                latitude:roomItinerary.Itinerary.HotelProperty.GeoCode.Latitude,
                // name:roomItinerary.Itinerary.HotelProperty.Name,
                image:roomItinerary.Itinerary.HotelProperty.MediaContent[0].Url,
                roomType:roomItinerary.Itinerary.Rooms[i].RoomName,
                roomDescription:roomItinerary.Itinerary.Rooms[i].RoomDescription,
                roomFare:roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.BaseEquivCurrency+" "+roomItinerary.Itinerary.Rooms[i].DisplayRoomRate.TotalFare.UsdEquivAmount,


=======
             if(roomItinerary[i].SupplierName=="HotelBeds Test"|| roomItinerary.SupplierName=="TouricoTGSTest")
           {
               typeOfRooms.push({
                image:roomItinerary[i].ImageUrl,
                roomType:roomItinerary[i].RoomName,
                roomDescription:roomItinerary[i].RoomDescription,
                roomFare:roomItinerary[i].CurrencyType+" "+roomItinerary[i].Price,
                latitude:roomItinerary[i].Latitude,
                longitude:roomItinerary[i].Longitude
>>>>>>> b13de8a8f5f4521a4d8b687528ee3c830650d9ea
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
                                     url: "http://localhost:64160/index/HotelListing/search/GetRoomPricing",
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



  