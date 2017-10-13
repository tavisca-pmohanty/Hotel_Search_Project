$(document).ready(function(){
	var data=sessionStorage.getItem('UpdatedRoomListing');
	var updatedData=JSON.parse(data);
	
	
	var inDate=updatedData.data.HotelItinerary.StayPeriod.Start.toString().split('T');
	var outDate=updatedData.data.HotelItinerary.StayPeriod.End.toString().split('T');
	var currencyType=updatedData.data.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
	var htmlData={
		hotelName:updatedData.data.HotelItinerary.HotelProperty.Name.toString(),
	 	roomType:updatedData.data.HotelItinerary.Rooms[0].RoomName.toString(),
	 	numOfRooms:updatedData.rooms.toString(),
	 	checkInDate:inDate[0].toString(),
	 	checkOutDate:outDate[0].toString(),
	 	duration:updatedData.data.HotelItinerary.StayPeriod.Duration.toString(),
	 	amount:(currencyType+" "+updatedData.data.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount).toString()
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