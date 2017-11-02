function sendRequest(uri,request,callback)
{
    try{
             $.ajax({
                 headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
    },
                 type: "POST",
                 url: uri,
                 cache: false,
                 data:JSON.stringify(request),
                // contentType: 'json/application',
                dataType: 'json',
                 success: callback,
                 crossDomain:true,
             });
         }
         catch(e)
         {
            alert("Sorry cannot connect to the server at this moment.Please try again later");
         }
}