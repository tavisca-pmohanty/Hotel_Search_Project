$(document).ready(function(){
 	var data=sessionStorage.getItem('UpdatedRoomListing');
 	var updatedData=JSON.parse(data);
	
	var inDate=updatedData.data.Itinerary.StayPeriod.Start.toString().split('T');
	var outDate=updatedData.data.Itinerary.StayPeriod.End.toString().split('T');
	var currencyType=updatedData.DisplayRoomRate.TotalFare.Currency;
	var htmlData={
		hotelName:" "+updatedData.data.HotelItinerary.HotelProperty.Name.toString(),
	 	roomType:" "+updatedData.data.HotelItinerary.Rooms[0].RoomName.toString(),
	 	numOfRooms:" "+updatedData.rooms.toString(),
	 	checkInDate:" "+inDate[0].toString(),
	 	checkOutDate:" "+outDate[0].toString(),
	 	duration:" "+updatedData.data.HotelItinerary.StayPeriod.Duration.toString(),
	 	amount:" "+(currencyType+" "+updatedData.data.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount).toString()
}
var template = $('#itinerary-details');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(htmlData);

  $('#booking-details').html(html);
  $("#booking").click(function(){
  			var cardNumber=$("#cardNum").val();
  			var cvv=$("#cvv").val();
  			var mobileNum=$("#mobile").val();
  			var cardDigits=cardNumber.split('');
  			var mobileDigits=mobileNum.split('');
  			if(mobileNum.length>10 || mobileNum.length<10)
  			{
  				alert("Please enter a valid mobile number");
  				return;
  			}
  			if(cardDigits.length>16 || cardDigits.length<16)
  			{
  				alert("Please enter a valid credit card number");
  				return;
  			}
  			if(cvv.length>3 || cardDigits.length<3)
  			{
  				alert("Please enter a valid cvv number");
  				return;
  			}
  });
});