Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});
    $(window).load(function() {
		// Animate loader off screen
		$(".se-pre-con").fadeOut("slow");;
	});


	$(document).ready(function(){
	var result=sessionStorage.getItem('HotelListing');
	result= JSON.parse(result);
	var hotelResult=result.HotelListingList;
		var hotelList= new Array();
		for(i=0;i<hotelResult.length;i++)
		{
			hotelList.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
			
		}
	  generateHandles('#hotel-item','#hotelList-container',hotelList);

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
				var data;
				var hotelName=this.value;
				for(var i=0;i<hotelResult.length;i++)
				{
					if(hotelName.toString()==(hotelResult[i].HotelName.toString()+" "+hotelResult[i].Address.toString()))
					{
						data=
						{
							HotelName:hotelResult[i].HotelName,
							SessionId:hotelResult[i].SessionId,
						}
						break;
					}
				}
						data=JSON.stringify(data);
						 sendRequest("http://localhost:59865/index/HotelListing/search/GetHotelRooms",data,function(result){
			             
			            	var roomItineraries=result;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						  
					});
		});
        
        
    $(window).load(function(){
	$('#preloader').fadeOut('slow',function(){$(this).remove();});
          });

	$('input[name="rating"]').change(function(e) 
	{
				var ratingSelected=this.value;
				var filteredHotelList= new Array();
				for(i=0;i<hotelResult.length;i++)
				{
					if(hotelResult[i].Rating==ratingSelected)
					{
						filteredHotelList.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
					}	
				}
				
				$("#hotelList-container").empty();
				generateHandles('#hotel-item','#hotelList-container',filteredHotelList);


	  	$(".room-button").click(function()
		{
				var data;
				var hotelName=this.value;
				for(var i=0;i<hotelResult.length;i++)
				{
					if(hotelName.toString()==(hotelResult[i].HotelName.toString()+" "+hotelResult[i].Address.toString()))
					{
						data=
						{
							HotelName:hotelResult[i].HotelName,
							SessionId:hotelResult[i].SessionId,
						}
						break;
					}
				}

				data=JSON.stringify(data);
						sendRequest("http://localhost:59865/index/HotelListing/search/GetHotelRooms",data,function(result){
             var roomItineraries=result;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						});
		});
	});



	  // filter for price

	 
		$('input:radio[name="price"]').change(function(e) 
		{
			var priceSelected=this.value;
			var filteredHotelListPrice= new Array();
			
			if(priceSelected==1)
					{
						for(i=0;i<hotelResult.length;i++)
						{
							if(hotelResult[i].Price>=400)
								{
									filteredHotelListPrice.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
									
								}
						}
					}

				else if (priceSelected==2) 
				{
					for(i=0;i<hotelResult.length;i++)
						{
							if (hotelResult[i].Price>=300 && hotelResult[i].Price<400)
							 {
							 	filteredHotelListPrice.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
							 }
						}
				}
				else if(priceSelected==3)
				{
					for(i=0;i<hotelResult.length;i++)
						{
							if(hotelResult[i].Price>=200 && hotelResult[i].Price<300)
							{
								filteredHotelListPrice.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
							}
						}
				}
				else if(priceSelected==4)
				{
					for(i=0;i<hotelResult.length;i++)
						{
							if (hotelResult[i].Price>=100 && hotelResult[i].Price<200) 
							{
								filteredHotelListPrice.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
							}
						}
				}

				else
				{
					for(i=0;i<hotelResult.length;i++)
						{
							if(hotelResult[i].Price>=0 && hotelResult[i].Price<100)
							{
								filteredHotelListPrice.push({
			image:hotelResult[i].ImageUrl,
			name:hotelResult[i].HotelName,
			city:hotelResult[i].Address,
			rating:hotelResult[i].Rating,
			price:hotelResult[i].CurrencyType+" "+hotelResult[i].Price,
            description:hotelResult[i].Description    
            });
							}
						}
				}

			$("#hotelList-container").empty();
			generateHandles('#hotel-item','#hotelList-container',filteredHotelListPrice);
		

	  // end of filter price



	  	$(".room-button").click(function()
		{
				var data;
				var hotelName=this.value;
				for(var i=0;i<hotelResult.length;i++)
				{
					if(hotelName.toString()==(hotelResult[i].HotelName.toString()+" "+hotelResult[i].Address.toString()))
					{
						data=
						{
							HotelName:hotelResult[i].HotelName,
							SessionId:hotelResult[i].SessionId,
						}
						break;
					}
				}
				requestData=JSON.stringify(data);
						sendRequest("http://localhost:53552/index/HotelListing/search/GetHotelRooms",requestData,function(result){		             
			            	var roomItineraries=result;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						});
		});
	  });
	  

		$("#remove-filters").click(function(){
			$('input[name=rating]').attr('checked',false);
			$('input[name=price]').attr('checked',false);
				$("#hotelList-container").empty();
		generateHandles('#hotel-item','#hotelList-container',hotelList);
});
	  	$(".room-button").click(function()
		{
				var data;
				var hotelName=this.value;
				for(var i=0;i<hotelResult.length;i++)
				{
					if(hotelName.toString()==(hotelResult[i].HotelName.toString()+" "+hotelResult[i].Address.toString()))
					{
						data=
						{
							HotelName:hotelResult[i].HotelName,
							SessionId:hotelResult[i].SessionId,
						}
						break;
					}
				}
				requestData=JSON.stringify(data);
						sendRequest("http://localhost:53552/index/HotelListing/search/GetHotelRooms",requestData,function(result){

			             
			            	var roomItineraries=result;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						});
		});
	});
