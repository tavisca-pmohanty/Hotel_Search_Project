$(document).ready(function()
{
	var data=sessionStorage.getItem('BookingSuccessfull');
	var updatedData=JSON.parse(data);
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

	  $('#confirmation-container').html(html);
});