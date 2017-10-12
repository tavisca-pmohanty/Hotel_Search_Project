
var data={
		hotelName:"Hyatt",
		roomType:"King Suite",
		roomFare:"Rs.2314.00",
		checkInDate:"23/10/2017",
		checkOutDate:"25/10/2017",
		duration:"2",
		numofRooms:"2",
		amount:"5000",
}

var template = $('#itinerary-details');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(data);

  $('#booking-details').html(html);