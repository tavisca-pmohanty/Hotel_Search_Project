$(document).ready(function(){

	var data=sessionStorage.getItem('UpdatedRoomListing');
	var updatedData=JSON.parse(data);
	
	
	var inDate=updatedData.data.HotelItinerary.StayPeriod.Start.toString().split('T');
	var outDate=updatedData.data.HotelItinerary.StayPeriod.End.toString().split('T');
	var currencyType=updatedData.data.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
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
  			var expiryMonth=$("#expiryMonth option:selected").val();
  			var expiryYear=$("#expiryYear option:selected").val();
  			var countryCode=$("#country-code option:selected").val();
  			var guestName=$("#guest-name").val();
  			var emailId=$("#email").val();
  			var cardHolderName=$("#cardHolder").val();
  			if(mobileNum.length>10 || mobileNum.length<10)
  			{
  				alert("Please enter a valid mobile number");
  				return;
  			}
  			if(cardNumber.length>16 || cardNumber.length<16)
  			{
  				alert("Please enter a valid credit card number");
  				return;
  			}
  			if(cvv.length>3 || cvv.length<3)
  			{
  				alert("Please enter a valid cvv number");
  				return;
  			}
  			if(expiryMonth==" ")
  			{
  				alert("Please enter a valid expiration month");
  				return;
  			}
  			if(expiryYear==" ")
  			{
  				alert("Please enter a valid expiration year");
  				return;
  			}
  			var tripFolderRequest={
  				TripDetails:updatedData.data,
  				SessionId:updatedData.sessionId,
  				GuestName:guestName,
  				CountryCode:countryCode,
  				MobileNum:mobileNum,
  				CardHolderName:cardHolderName,
  				ExpiryMonth:expiryMonth,
  				ExpiryYear:expiryYear,
  				Cvv:cvv,
  				Email_Id:emailId
  			}
  			var data=JSON.stringify(tripFolderRequest);
  			try {
             $.ajax({
                 headers: { 
       						 'Accept': 'application/json',
        					'Content-Type': 'application/json' 
   				 },
                 type: "POST",
                 url: "http://localhost:64160/api/tripfolder/booktrip",
                 cache: false,
                 data:JSON.stringify(data),
                dataType: 'json',
                
                 success: getSuccess,
                 crossDomain:true,
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(data) { 
         }
  });
});