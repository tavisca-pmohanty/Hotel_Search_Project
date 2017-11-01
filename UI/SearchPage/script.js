function sendRequest(uri,request,callback)
{
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