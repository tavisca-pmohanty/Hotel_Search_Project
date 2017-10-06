$(document).ready(function(){ 
$("#rooms").on("change",function(){
	 				$("#rooms-info").empty();
	 				 val=$("#rooms option:selected").val();
	 				 	for(i=1;i<=val;i++)
	 				{
	 				 var appendRooms="<div id=\"room-info-flex\">\
	 				 <p id=\"adultsText\" class=\"text-info\">Adults(18+)</p>\
	 				 <p id=\"childenText\" class=\"text-info\">Children(0-17)</p>\
	 				 </div>";
	 				 var appendRoomInfo="<div id=\"room-input-box\">\
                    <select id=\"adults\">\
                        <option value=\"1\">1</option>\
                        <option value=\"2\">2</option>\
                        <option value=\"3\">3</option>\
                        <option value=\"4\">4</option>\
                        <option value=\"5\">5</option>\
                        <option value=\"6\">6</option>\
                    </select>";

                    appendRoomInfo+="<select id=\"children" +i+"\">";
                        appendRoomInfo+="<option value=\"0\">0</option>\
                        <option value=\"1\">1</option>\
                        <option value=\"2\">2</option>\
                        <option value=\"3\">3</option>\
                        <option value=\"4\">4</option>\
                        <option value=\"5\">5</option>\
                        <option value=\"6\">6</option>\
                    </select>\
                    </div>";
	 			
	 					 var individualRoom = "<div id=roomNumber"+(i)+"><p>Room " + (i) + "</p></div>";
	 					$("#rooms-info").append(individualRoom);
	 					$("#rooms-info").append(appendRooms);
  						$("#rooms-info").append(appendRoomInfo);
  						}
	 });
    var selectedHotel= new Array(13);
		$("#Location").on("input",function(){
         try {
             $.ajax({
                 type: "GET",
                 url: "http://localhost:51052//index/AutoComplete/search/"+ $("#Location").val(),
                 cache: false,
                 success: getSuccess,
                 
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(data) {
         	var obj=JSON.parse(data);
         	var hotelList= new Array(obj.length);
         	for(var i=0;i<obj.length;i++)
         	{
         		hotelList[i]=obj[i].HotelName+","+obj[i].CityName+","+obj[i].StateCode+","+obj[i].CountryCode;
         	}

         	 $( "#Location" ).autocomplete({
         	
      source:hotelList,
      minLength: 2,
      select: function( event, ui ) {
        var hotel=ui.item.value.split(",");
         for(var i=0;i<obj.length;i++)
         {
          if(obj[i].HotelName.toString()==hotel[0].toString())
          {
           
                        selectedHotel[0]=obj[i].ID.toString();
                        selectedHotel[1]=obj[i].HotelName.toString();
                        selectedHotel[2]=obj[i].CityName.toString();
                        selectedHotel[3]=obj[i].StateCode.toString();
                        selectedHotel[4]=obj[i].CountryCode.toString();
                        selectedHotel[5]=obj[i].Latitude.toString();
                        selectedHotel[6]=obj[i].Longitude.toString();
                        selectedHotel[7]=obj[i].SearchType.toString();
          
          }
         }
       }
    } );
     };
         
 });
	});