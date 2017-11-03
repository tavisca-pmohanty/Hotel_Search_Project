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
generateHandles('#itinerary-details','#booking-details',htmlData);
  $("#booking").click(function(){
        $("#booking").attr("disabled","disabled");
  			var cardNumber=$("#cardNum").val();
  			var cvv=$("#cvv").val();
            if(!ValidateCard(cardNumber))
                {
                 
                    alert("please Enter Valid Card Number");
                    $("#booking").removeAttr("disabled");
                    return;
                    
                }

  function ValidateCard(number) 
      {
          
          var num= number.length;
          if(num>12 && num<20)
          {
               var regex = new RegExp("^[0-9]{16}$");
               if (!regex.test(number))
               
                   return false;
              
              return luhnCheck(number);
          }
          else
              {
          return false;
              }
    }             
     function luhnCheck(val) 
      {
       var sum = 0;
            for (var i = 0; i < val.length; i++) 
            {
               var intVal = parseInt(val.substr(i, 1));
                   if (i % 2 == 0) {
                         intVal *= 2;
                        if (intVal > 9) 
                        {
                          intVal = 1 + (intVal % 10);
                               }
        }
        sum += intVal;
        }
              return (sum % 10) == 0;
                     


    }
      
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
        if(ValidateEmail(emailId)==false)
          {
              $("#booking").removeAttr("disabled");
  				alert("Please enter a valid email ID");
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
  			var requestData=JSON.stringify(tripFolderRequest);
  			sendRequest("http://localhost:53552/book/tripfolder/BookTrip",requestData,function(result){
          var data=JSON.stringify(result);
             sendRequest("http://localhost:53552/complete/booking/bookingcomplete",data,function(result){
              if(result.Status=="Success")
              {
                var responseData={
                  data:result,
                  Email_Id:emailId
                }
                sessionStorage.setItem('BookingSuccessfull',JSON.stringify(responseData));
                  sessionStorage.setItem('MobileNumber',mobileNum);
                        window.location="ConfirmationPage.html";
                  
              }
              else
              {
                alert("Cannot confirm your booking at this moment.Please try again after sometime");
                $("#booking").removeAttr("disabled");
                return;
              }
              
         });

         });
      function ValidateEmail(mail)   
      {  
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail))  
        {  
            return (true);  
        }  
            return (false);  
      }  
  });
});