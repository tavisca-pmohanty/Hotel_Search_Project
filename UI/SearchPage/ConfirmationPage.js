$(document).ready(function()
{
	var data=sessionStorage.getItems('BookingSuccessfull');
	var updatedData=JSON.parse(data);
	var confirmationDataList= new Array();
	for(i=0;i<updatedData.length;i++)
	{
		confirmationDataList.push(
		{
			transactionId:updatedData.completeBookingResponseData.TransactionId,
			hotel-name:updatedData.completeBookingResponseData.HotelName,
			roomName:updatedData.completeBookingResponseData.RoomName,
			checkIn:updatedData.completeBookingResponseData.CheckInDate,
			checkOut:updatedData.completeBookingResponseData.CheckOutDate,
			noOfNights:updatedData.completeBookingResponseData.NumOfNights,
		});
	}
	var template = $('#confirmation-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(confirmationDataList);

	  $('#confirmation-container').html(html);
}