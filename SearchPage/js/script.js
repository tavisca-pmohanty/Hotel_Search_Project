$(document).ready(function(){ 
$("#rooms").on("change",function(){
	 				$("#rooms-info").empty();
	 				 val=$("#rooms option:selected").val();
	 				 	for(i=0;i<val;i++)
	 				{
	 				 var appendRooms="<div id=\"room-info-flex\">\
	 				 <p id=\"adultsText\" class=\"text-info\">Adults(18+)</p>\
	 				 <p id=\"childenText\" class=\"text-info\">Children(0-17)</p>\
	 				 </div>";
	 				 var appendRoomInfo="<div id=\"room-input-box\">";
                    $("#rooms-info").empty();
                     val=$("#rooms option:selected").val();
                        for(i=0;i<val;i++)
                    {
                     var appendRooms="<div id=\"room-info-flex\">\
                     <p id=\"adultsText\" class=\"text-info\">Adults(18+)</p>\
                     <p id=\"childenText\" class=\"text-info\">Children(0-17)</p>\
                     </div>";
                     var appendRoomInfo="<div id=\"room-input-box\">\
                      <select id=\"adults" +i+"\">\
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
                    }
	 });
    var selectedHotel;
		$("#Location").on("input",function(){

                
                         var individualRoom = "<div id=roomNumber"+(i)+"><p>Room " + (i) + "</p></div>";
                        $("#rooms-info").append(individualRoom);
                        $("#rooms-info").append(appendRooms);
                        $("#rooms-info").append(appendRoomInfo);
                        }
     });
    var selectedHotel;
        $("#Location").on("input",function(){
         try {
             $.ajax({
                 type: "GET",
                 url: "http://localhost:51052//index/AutoComplete/search/"+ $("#Location").val(),
                 cache: false,
                 success: getSuccess,
                 crossDomain:true,
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(data) {
         	var obj=JSON.parse(data);
         	var hotelList= new Array();
         	for(var i=0;i<obj.length;i++)
         	{
         		hotelList.push({
              value:obj[i].CulteredText,
              data:obj[i],
            });
         	}

         	 $( "#Location" ).autocomplete({
         	
            var obj=JSON.parse(data);
            var hotelList= new Array();
            for(var i=0;i<obj.length;i++)
            {
                hotelList.push({
              value:obj[i].CulteredText,
              data:obj[i],
            });
            }

             $( "#Location" ).autocomplete({
            
      source:hotelList,
      minLength: 2,
      select: function( event, ui ) {
         for(var i=0;i<hotelList.length;i++)
         {
          if(ui.item.value.toString()==hotelList[i].data.CulteredText.toString())
          {
            selectedHotel=hotelList[i].data;
          }
         }
       }
    } );
     };
         
 });

    $("#submit").on("click",function(){
        inDate=$("#indate").val().toString();
        outDate=$("#outdate").val().toString();
        numOfRooms=$("#rooms option:selected").val().toString();
        var adults=0;
        var children=0;
        for(var i=0;i<numOfRooms;i++)
        {
          var adultId="#adults"+i+" "+"option:selected";
          var childrenId="#children"+i+" "+"option:selected";
          adults=adults+parseInt($(adultId).val());
          children=children+parseInt($(childrenId).val());
        }
        numOfAdults=adults.toString();
        numOfChildren=children.toString();
        var requestData={
                        "SelectedHotel":selectedHotel,
                        "InDate":inDate,
                        "OutDate":outDate,
                        "Rooms":numOfRooms,
                        "Adults":adults,
                        "Children":children,
        }
    });
    });