
$(document).ready(function(){
                
    var data=sessionStorage.getItem('RoomListing');
   var roomItinerary= JSON.parse(data);
        var typeOfRooms= new Array();
    
    for(var i=0;i<roomItinerary.Itinerary.Rooms.length;i++)
       {
      //       var imageUrl="";
      // for(j=0;j<result[i].itinerary.HotelProperty.MediaContent.length;j++)
      //   {
      //     if(result[i].itinerary.HotelProperty.MediaContent[j].Url!=null)
      //     {
      //     imageUrl=result[i].itinerary.HotelProperty.MediaContent[j].Url.toString();
      //     break;
      //     }
      //   }
            typeOfRooms.push({
                image:roomItinerary.Itinerary.HotelProperty.MediaContent[0].Url,
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

$(".room-button").click(function()
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
            function getSuccess(dynamicData)
                    {
                      var dynamicPricing;
                      if(data.Itinerary==null)
                      {
                         dynamicPricing={
                              data:data,
                              roomSelected:roomName
                        };
                      }
                      else
                      {
                        dynamicPricing={
                              data:dynamicData,
                              roomSelected:roomName
                        }
                      }
                        
                        sessionStorage.setItem('HotelListing',JSON.stringify(dynamicPricing));
			            window.location="Guest-Details.html";
                    }
                });      
});



  