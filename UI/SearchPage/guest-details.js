$(document).ready(function(){

	var data=sessionStorage.getItem('UpdatedRoomListing');
	var updatedData=JSON.parse(data);
	var inDate=updatedData.CheckInDate.toString().split('T');
	var outDate=updatedData.CheckOutDate.toString().split('T');
	var currencyType=updatedData.CurrencyType;
	var htmlData={
		hotelName:" "+updatedData.HotelName,
	 	roomType:" "+updatedData.RoomName,
	 	numOfRooms:" "+updatedData.rooms,
	 	checkInDate:" "+inDate[0],
	 	checkOutDate:" "+outDate[0],
	 	duration:" "+updatedData.Duration,
	 	amount:" "+(currencyType+" "+updatedData.Price)
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
  			var guestFirstName=$("#guest-Fname").val();
            var guestLastName=$("#guest-Lname").val();      
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
  				SessionId:updatedData.SessionId,
  				GuestFName:guestFirstName,
                GuestLName:guestLastName,
  				CountryCode:countryCode,
                CardNumber:cardNumber,
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
                 url: "http://localhost:64160/book/tripfolder/booktrip",
                 cache: false,
                 data:JSON.stringify(data),
                dataType: 'json',
                
                 success: getSuccess,
                 crossDomain:true,
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(tripFolderResponseData) {
          var data=JSON.stringify(tripFolderResponseData);
              try {
             $.ajax({
                 headers: { 
                   'Accept': 'application/json',
                  'Content-Type': 'application/json' 
           },
                 type: "POST",
                 url: "http://localhost:64160/complete/booking/bookingcomplete",
                 cache: false,
                 data:JSON.stringify(data),
                dataType: 'json',
                
                 success: getSuccess,
                  statusCode: {
                  500: function(xhr) {
                   alert('page not found');
                    }},
                 crossDomain:true,
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(completeBookingResponseData) {
              if(completeBookingResponseData!=null)
              {
                var responseData={
                  data:completeBookingResponseData,
                  Email_Id:emailId
                }
                sessionStorage.setItem('BookingSuccessfull',JSON.stringify(responseData));
                        window.location="ConfirmationPage.html";
              }
              else
              {
                alert("Cannot confirm your booking at this moment.Please try again after sometime");
                return;
              }
              
         }

         }
  });
});