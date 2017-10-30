$(document).ready(function(){

	var data=sessionStorage.getItem('UpdatedRoomListing');
	var updatedData=JSON.parse(data);
	var inDate=updatedData.CheckInDate.toString().split('T');
	var outDate=updatedData.CheckOutDate.toString().split('T');
	var currencyType=updatedData.CurrencyType;
	var htmlData={
		hotelName:" "+updatedData.HotelName,
	 	roomType:" "+updatedData.RoomName,
	 	numOfRooms:" "+updatedData.NumOfRooms,
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
        $("#booking").attr("disabled","disabled");
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
          $("#booking").removeAttr("disabled");
  				alert("Please enter a valid mobile number");
  				return;
  			}
  			if(cardNumber.length>16 || cardNumber.length<16)
  			{
          $("#booking").removeAttr("disabled");
  				alert("Please enter a valid credit card number");
  				return;
  			}
  			if(cvv.length>3 || cvv.length<3)
  			{
          $("#booking").removeAttr("disabled");
  				alert("Please enter a valid cvv number");
  				return;
  			}
  			if(expiryMonth==" ")
  			{
          $("#booking").removeAttr("disabled");
  				alert("Please enter a valid expiration month");
  				return;
  			}
  			if(expiryYear==" ")
  			{
          $("#booking").removeAttr("disabled");
  				alert("Please enter a valid expiration year");
  				return;
  			}
        
        var guestDetails={
          GuestFirstName:guestFirstName,
          GuestLastName:guestLastName,
        }
  			var tripFolderRequest={
  				SessionId:updatedData.SessionId,
  				Name:guestDetails,
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
              $("#booking").removeAttr("disabled");
             alert("Sorry some unknown Error Occured...Please try again later.");
                    Console.log(e);
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
             alert("Sorry some unknown Error Occured...Please try again later.");
                    Console.log(e);
         }
         function getSuccess(completeBookingResponseData) {
              if(completeBookingResponseData.Status=="Success")
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
                $("#booking").removeAttr("disabled");
                return;
              }
              
         }

         }
  });
});