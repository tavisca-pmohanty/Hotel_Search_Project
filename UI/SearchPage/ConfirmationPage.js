$(document).ready(function()
{
    var mobileNumber=sessionStorage.getItem('MobileNumber');
	var responseData=sessionStorage.getItem('BookingSuccessfull');
	var updatedData=JSON.parse(responseData);
		var confirmationDataList=
		{
			transactionId:updatedData.data.TransactionId,
			hotelName:updatedData.data.HotelName,
			roomName:updatedData.data.RoomName,
			checkIn:updatedData.data.CheckInDate,
			checkOut:updatedData.data.CheckOutDate,
			noOfNights:updatedData.data.NumOfNights,
		};
	var template = $('#confirmation-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(confirmationDataList);

	  $('#confirmation-container').append(html);
    
    
        try {
             $.ajax({
                 headers: { 
                   'Accept': 'application/json',
                  'Content-Type': 'application/json' 
           },
                 type: "POST",
                 url: "http://localhost:53552/Textmessage/SendMessage",
                  cache: false,
                 data:JSON.stringify(mobileNumber),
                dataType: 'json',
                 success: getSuccess,
                 crossDomain:true,
             });
         } 
    catch (e) {
             alert("Unfortunately message Could not be Sent");
                    Console.log(e);
         }
    function getSuccess(result)
    {
        if(result.Status==0)
            {
                alert("SMS sent to your phone number successfully.");
            }
    }
    
});