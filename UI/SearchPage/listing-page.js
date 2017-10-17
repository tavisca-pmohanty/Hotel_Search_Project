Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});


	$(document).ready(function(){
	var result=sessionStorage.getItem('HotelListing');
	result= JSON.parse(result);
		var hotelList= new Array();
		for(i=0;i<result.length;i++)
		{
			
			var imageUrl="";
			for(j=0;j<result[i].itinerary.HotelProperty.MediaContent.length;j++)
				{
					if(result[i].itinerary.HotelProperty.MediaContent[j].Url!=null)
					{
					imageUrl=result[i].itinerary.HotelProperty.MediaContent[j].Url.toString();
					break;
					}
				}
			hotelList.push({
			image:imageUrl,
			name:result[i].itinerary.HotelProperty.Name,
			city:result[i].itinerary.HotelProperty.Address.City.Name,
			rating:result[i].itinerary.HotelProperty.HotelRating.Rating,
			price:result[i].itinerary.Fare.TotalFare.BaseEquivCurrency+" "+result[i].itinerary.Fare.TotalFare.UsdEquivAmount,
            });
			
		}

		
		
	  var template = $('#hotel-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(hotelList);

	  $('#hotelList-container').html(html);

	function myFunction() 
	{
	    var x = document.getElementById("myTopnav");
	    if (x.className === "topnav") 
	    {
	        x.className += " responsive";
	    } 
	    else 
	    {
	        x.className = "topnav";
	    }
	}
		$(".room-button").click(function()
		{
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].itinerary.HotelProperty.Name.toString()+" "+result[i].itinerary.HotelProperty.Address.City.Name.toString()))
					{
						var data=JSON.stringify(result[i]);
						 try
						  {
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",

					                 url: "http://localhost:49898/index/HotelListing/search/GetHotelRooms",
					                 cache: false,
					                 data:JSON.stringify(data),
					                 dataType: 'json',
					                
					                 success: getSuccess,
					                 crossDomain:true,
					             });
					      } 
					    catch (e)
					     {
					         	alert(e);
					     }
			         function getSuccess(data)
			          {
			             
			            	var roomItineraries=data;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						  
					}
				}
				}
		});
		$('input[type="radio"]').on('click change', function(e) {
   				var ratingSelected=this.value;
   				var filteredHotelList= new Array();
		for(i=0;i<result.length;i++)
		{
			if(result[i].itinerary.HotelProperty.HotelRating.Rating==ratingSelected)
			{
			var imageUrl="";
			for(j=0;j<result[i].itinerary.HotelProperty.MediaContent.length;j++)
				{
					if(result[i].itinerary.HotelProperty.MediaContent[j].Url!=null)
					{
					imageUrl=result[i].itinerary.HotelProperty.MediaContent[j].Url.toString();
					break;
					}
				}
			filteredHotelList.push({
			image:imageUrl,
			name:result[i].itinerary.HotelProperty.Name,
			city:result[i].itinerary.HotelProperty.Address.City.Name,
			rating:result[i].itinerary.HotelProperty.HotelRating.Rating,
			price:result[i].itinerary.Fare.TotalFare.Currency+" "+result[i].itinerary.Fare.TotalFare.Amount,
			});
		}
		}
		$("#hotelList-container").empty();
		var template = $('#hotel-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(filteredHotelList);

	  $('#hotelList-container').html(html);
	  	$(".room-button").click(function()
		{
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].itinerary.HotelProperty.Name.toString()+" "+result[i].itinerary.HotelProperty.Address.City.Name.toString()))
					{
						var data=JSON.stringify(result[i]);
						 try
						  {
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",

					                 url: "http://localhost:49898/index/HotelListing/search/GetHotelRooms",
					                 cache: false,
					                 data:JSON.stringify(data),
					                 dataType: 'json',
					                
					                 success: getSuccess,
					                 crossDomain:true,
					             });
					      } 
					    catch (e)
					     {
					         	alert(e);
					     }
			         function getSuccess(data)
			          {
			             
			            	var roomItineraries=data;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						  
					}
				}
				}
		});

			});

	});

