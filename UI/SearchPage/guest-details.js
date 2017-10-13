$(document).ready(function(){
	var data=sessionStorage.getItem('UpdatedRoomListing');
	var updatedItinerary=JSON.parse(data);
	
	var roomData;
	for(var i=0;i<updatedItinerary.data.Itinerary.Rooms.length;i++)
	{
		if(updatedItinerary.data.Itinerary.Rooms[i].RoomName.toString()==updatedItinerary.roomSelected.toString())
		{
			roomData=updatedItinerary.data.Itinerary.Rooms[i];
			break;
		}
	}
	var inDate=updatedItinerary.data.Itinerary.StayPeriod.Start.toString().split('T');
	var outDate=updatedItinerary.data.Itinerary.StayPeriod.End.toString().split('T');
	var currencyType=roomData.DisplayRoomRate.TotalFare.Currency;
	var htmlData={
		hotelName:updatedItinerary.data.Itinerary.HotelProperty.Name,
	 	roomType:roomData.RoomName,
	 	numOfRooms:updatedItinerary.rooms,
	 	roomFare:currencyType+" "+roomData.DisplayRoomRate.TotalFare.Amount,
	 	checkInDate:inDate[0],
	 	checkOutDate:outDate[0],
	 	duration:updatedItinerary.data.Itinerary.StayPeriod.Duration,
	 	amount:currencyType+" "+eval(roomData.DisplayRoomRate.TotalFare.Amount*updatedItinerary.rooms*updatedItinerary.data.Itinerary.StayPeriod.Duration)
}
var template = $('#itinerary-details');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(htmlData);

  $('#booking-details').html(html);
  $("#booking").click(function(){
  			var cardNumber=$("#cardNum").val();
  			var cvv=$("#cvv").value;
  			var mobileNum=$("#mobile").val();
  			var cardDigits=cardNumber.split('');
  			var mobileDigits=mobileNum.split('');
  });
});