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
		var hotelList= new Array();
		for(i=0;i<result.length;i++)
		{
			hotelList.push({
			image:result[i].ImageUrl,
			name:result[i].HotelName,
			city:result[i].Address,
			rating:result[i].Rating,
			price:result[i].CurrencyType+" "+result[i].Price,
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
				var data;
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].HotelName.toString()+" "+result[i].Address.toString()))
					{
						data=
						{
							HotelName:result[i].HotelName,
							SessionId:result[i].SessionId,
						}
						break;
					}
				}
						data=JSON.stringify(data);
						 try
						  {
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",
					                 url: "http://localhost:53552/index/HotelListing/search/GetHotelRooms",
					                 cache: false,
					                 data:JSON.stringify(data),
					                 dataType: 'json',
					                
					                 success: getSuccess,
					                 crossDomain:true,
					             });
					      } 
					    catch (e)
					     {
					         	alert("Sorry some unknown Error Occured...Please try again later.");
					         	Console.log(e);
					     }
			         function getSuccess(data)
			          {
			             
			            	var roomItineraries=data;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						  
					}
		});
        
        
    $(window).load(function(){
	$('#preloader').fadeOut('slow',function(){$(this).remove();});
          });

	$('input[name="rating"]').change(function(e) 
	{
				var ratingSelected=this.value;
				var filteredHotelList= new Array();
				for(i=0;i<result.length;i++)
				{
					if(result[i].Rating==ratingSelected)
					{
						filteredHotelList.push({
												image:result[i].ImageUrl,
												name:result[i].HotelName,
												city:result[i].Address,
												rating:result[i].Rating,
												price:result[i].CurrencyType+" "+result[i].Price,
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
				var data;
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].HotelName.toString()+" "+result[i].Address.toString()))
					{
						data=
						{
							HotelName:result[i].HotelName,
							SessionId:result[i].SessionId,
						}
						break;
					}
				}
				data=JSON.stringify(data);
						try
						{
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",
					                 url: "http://localhost:53552/index/HotelListing/search/GetHotelRooms",
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
		});
	});



	  // filter for price

	 
		$('input:radio[name="price"]').change(function(e) 
		{
			var priceSelected=this.value;
			var filteredHotelListPrice= new Array();
			
			if(priceSelected==1)
					{
						for(i=0;i<result.length;i++)
						{
							if(result[i].Price>=400)
								{
									filteredHotelListPrice.push({
										image:result[i].ImageUrl,
										name:result[i].HotelName,
										city:result[i].Address,
										rating:result[i].Rating,
										price:result[i].CurrencyType+" "+result[i].Price,
									});
									
								}
						}
					}

				else if (priceSelected==2) 
				{
					for(i=0;i<result.length;i++)
						{
							if (result[i].Price>=300 && result[i].Price<400)
							 {
							 	filteredHotelListPrice.push({
										image:result[i].ImageUrl,
										name:result[i].HotelName,
										city:result[i].Address,
										rating:result[i].Rating,
										price:result[i].CurrencyType+" "+result[i].Price,
									});
							 }
						}
				}
				else if(priceSelected==3)
				{
					for(i=0;i<result.length;i++)
						{
							if(result[i].Price>=200 && result[i].Price<300)
							{
								filteredHotelListPrice.push({
										image:result[i].ImageUrl,
										name:result[i].HotelName,
										city:result[i].Address,
										rating:result[i].Rating,
										price:result[i].CurrencyType+" "+result[i].Price,
									});
							}
						}
				}
				else if(priceSelected==4)
				{
					for(i=0;i<result.length;i++)
						{
							if (result[i].Price>=100 && result[i].Price<200) 
							{
								filteredHotelListPrice.push({
										image:result[i].ImageUrl,
										name:result[i].HotelName,
										city:result[i].Address,
										rating:result[i].Rating,
										price:result[i].CurrencyType+" "+result[i].Price,
									});
							}
						}
				}

				else
				{
					for(i=0;i<result.length;i++)
						{
							if(result[i].Price>=0 && result[i].Price<100)
							{
								filteredHotelListPrice.push({
										image:result[i].ImageUrl,
										name:result[i].HotelName,
										city:result[i].Address,
										rating:result[i].Rating,
										price:result[i].CurrencyType+" "+result[i].Price,
									});
							}
						}
				}

			$("#hotelList-container").empty();
			var template = $('#hotel-item');

	  		var compiledTemplate = Handlebars.compile(template.html());

		  	var html = compiledTemplate(filteredHotelListPrice);
		   	$('#hotelList-container').append(html);

		

	  // end of filter price



	  	$(".room-button").click(function()
		{
				var data;
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].HotelName.toString()+" "+result[i].Address.toString()))
					{
						data=
						{
							HotelName:result[i].HotelName,
							SessionId:result[i].SessionId,
						}
						break;
					}
				}
				data=JSON.stringify(data);
						try
						{
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",
					                 url: "http://localhost:53552/index/HotelListing/search/GetHotelRooms",
					                 cache: false,
					                 data:JSON.stringify(data),
					                 dataType: 'json',
					                
					                 success: getSuccess,
					                 crossDomain:true,
					            });
					    } 
					    catch (e)
					     {
					         	alert("Sorry some unknown Error Occured...Please try again later.");
					         	Console.log(e);
					     }
			         function getSuccess(data)
				        {
			             
			            	var roomItineraries=data;
            				sessionStorage.setItem('RoomListing',JSON.stringify(roomItineraries));

             				window.location="roomDetail.html";
						}
		});
	  });
	  

		$("#remove-filters").click(function(){
			$('input[name=rating]').attr('checked',false);
			$('input[name=price]').attr('checked',false);
				$("#hotelList-container").empty();
		var template = $('#hotel-item');

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(hotelList);

	  $('#hotelList-container').html(html);

	  	$(".room-button").click(function()
		{
				var data;
				var hotelName=this.value;
				for(var i=0;i<result.length;i++)
				{
					if(hotelName.toString()==(result[i].HotelName.toString()+" "+result[i].Address.toString()))
					{
						data=
						{
							HotelName:result[i].HotelName,
							SessionId:result[i].SessionId,
						}
						break;
					}
				}
				data=JSON.stringify(data);
						try
						{
					             $.ajax({
					                headers: 
					                { 
						       		 	'Accept': 'application/json',
						        		'Content-Type': 'application/json' 
					    			},
					                 type: "POST",
					                 url: "http://localhost:53552/index/HotelListing/search/GetHotelRooms",
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
		});
		});
	});

