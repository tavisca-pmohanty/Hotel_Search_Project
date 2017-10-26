$(document).ready(function(){ 
    $("#loaderdiv").hide();
    $("#Location").value="";
    var changeInDate='0m+1d';
    $("#indate").datepicker({
        changeMonth: true,
                    changeYear: true,
                    minDate: '0m+0d',
        dateFormat:'yy-mm-dd',
        onSelect: function () {
            var checkOutDate = $('#outdate');
            var startDate = $(this).datepicker('getDate');
            startDate.setDate(startDate.getDate() + 1);
            var minDate = $(this).datepicker('getDate');
            checkOutDate.datepicker('setDate', startDate);
            checkOutDate.datepicker('option', 'minDate', minDate);
        }
    });
    $("#outdate").datepicker({
        changeMonth: true,
                    changeYear: true,
                    minDate: '0m+1d',
        dateFormat:'yy-mm-dd'});
    
$("#rooms").on("change",function(){
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
                
                         var individualRoom = "<div id=roomNumber"+(i)+"><p>Room " + (i+1) + "</p></div>";
                        $("#rooms-info").append(individualRoom);
                        $("#rooms-info").append(appendRooms);
                        $("#rooms-info").append(appendRoomInfo);
                        }
     });
    var hotelName=""; 
    var selectedHotel;
        $("#Location").on("input",function(){
         try {
             $.ajax({
                 type: "GET",
                 url: "http://localhost:56883/index/AutoComplete/search/"+ $("#Location").val(),
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
            
      source:hotelList,
      minLength: 2,
      select: function( event, ui ) {
        hotelName=ui.item.value.toString();
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
    
    
    
    
    window.onload = function() {

       
        if (sessionStorage.getItem('Storedlocation') == "Storedlocation") {
            return;
        }

        // If values are not blank, restore them to the fields
        var location= sessionStorage.getItem('Storedlocation');
        if (location !== null){
            $('#Location').val(location);
            hotelName=location;
                  }
        var indate = sessionStorage.getItem('Storedindate');
        if (indate !== null){ $('#indate').val(indate);
                             inDate=indate;
                            }

        var rooms= sessionStorage.getItem('StoredRoomsCount');
        if (rooms!== null) { 
            $('#rooms').val(rooms);
            rooms=rooms;
            
        }
        var adults= sessionStorage.getItem('StoredAdultsCount');
        if (adults!== null) $('#adults0').val(adults);
        var children= sessionStorage.getItem('StoredChildrenCount');
        if(children!==null) $('#children0').val(children);
        
        var outDate= sessionStorage.getItem('StoredOutDateCount');
        if(outDate!==null) 
        {
            $('#outdate').val(outDate);
        
             outDate=outDate;
        }
        //var SelectedHotelonload=sessionStorage.getItem('StoredSelectedHotel');
         
        //if(SelectedHotelonload!==null)
          //  {
                //selectedHotel=SelectedHotelonload;
        //    }
         var retrievedSelectedHotel = sessionStorage.getItem('StoredSelectedHotel');
       selectedHotel =JSON.parse(retrievedSelectedHotel);
    }

    // Before refreshing the page, save the form data to sessionStorage
    window.onbeforeunload = function() 
    {
        sessionStorage.setItem("Storedlocation", $('#Location').val());
        sessionStorage.setItem("Storedindate", $('#indate').val());
        sessionStorage.setItem("StoredRoomsCount", $('#rooms').val());
        sessionStorage.setItem("StoredAdultsCount", $('#adults0').val());
        sessionStorage.setItem("StoredChildrenCount",$('#children0').val());
        sessionStorage.setItem("StoredOutDateCount",$('#outdate').val());
        sessionStorage.setItem('StoredSelectedHotel', JSON.stringify(selectedHotel));
        
    
    }
    
    

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
        if(hotelName.toString()=="") 
        {
            alert("Search field must be filled");
            return;
        }
        if(inDate.toString()=="") 
        {
            alert("Check-In date field must be filled");
            return;
        }
         if(outDate.toString()=="") 
        {
            alert("Check-Out date field must be filled");
            return;
        }
        $("#loaderdiv").show();
        $("#submit").attr("disabled","disabled");
        var requestData={
                        "SelectedHotel":selectedHotel,
                        "InDate":inDate,
                        "OutDate":outDate,
                        "Rooms":numOfRooms,
                        "Adults":adults,
                        "Children":children,
        };
        var data=JSON.stringify(requestData);
        try {
             $.ajax({
                 headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
    },
                 type: "POST",

                 url: "http://localhost:56883/index/HotelListing/search/GetHotels",

                 cache: false,
                 data:JSON.stringify(data),
                // contentType: 'json/application',
                dataType: 'json',
                
                 success: getSuccess,
                 crossDomain:true,
             });
         } catch (e) {
             alert(e);
         }
         function getSuccess(data) { 
         if(data.length==0)
         {
            alert("Sorry,Could not fetch the hotel details at this moment.Please try again after sometime");
            $("#loaderdiv").hide();
            $("#submit").removeAttr("disabled");
            return;
         } 
         else{

             window.location="listing-page.html";
             sessionStorage.setItem('HotelListing',JSON.stringify(data));
         }
            }
    });
});
