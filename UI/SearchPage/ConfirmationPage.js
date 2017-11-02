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
    
    
        sendRequest("http://localhost:59865/TextMessage/SendMessage",mobileNumber,function(result){
        if(result.Status==0)
            {
                alert("SMS sent to your phone number successfully.");
            }
            else
            {
                alert("Not able to send sms at this moment.");
            }
    });
    
});