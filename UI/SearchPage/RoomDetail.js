
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
    var roomData=JSON.parse(data);
   var roomItinerary= roomData.HotelRoomList;

        var typeOfRooms= new Array();
         var commonData= new Array();
    for(var i=0;i<roomItinerary.length;i++)
       {
 if(roomItinerary[i].SupplierName=="TouricoTGSTest"||roomItinerary[i].SupplierName=="HotelBeds Test")
           {

               typeOfRooms.push({
                roomType:roomItinerary[i].RoomName,
                roomDescription:roomItinerary[i].Description,
                roomFare:roomItinerary[i].CurrencyType+" "+roomItinerary[i].Price,
                latitude:roomItinerary[i].Latitude,
                longitude:roomItinerary[i].Longitude
            });

           }
      }
  var temp = $("#common-item");
    var cmp = Handlebars.compile(temp.html());
    var htm = cmp({
      image:roomItinerary[0].ImageUrl,
        hotelname: roomItinerary[0].HotelName,
        latitude:roomItinerary[0].Latitude,
        longitude:roomItinerary[0].Longitude
    });

         // }
      
      

   

  var template = $('#room-item');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(typeOfRooms);

  $('#roomlist-container').html(htm);
  $('#roomlist-container').append(html);

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
                                     url: "http://localhost:53552/index/HotelListing/search/GetRoomPricing",
                                     cache: false,
                                     data:JSON.stringify(data),
                                     dataType: 'json',
                                    
                                     success: getSuccess,
                                     crossDomain:true,
                                 });
                          } 
                        catch (e)
                         {
                                alert("Sorry some unknown Error Occured...Please try again later.");
                                Console.log(e);
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



  