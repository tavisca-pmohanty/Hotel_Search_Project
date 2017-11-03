function generateHandles(templateDiv,containerDiv,data)
{
	var template = $(templateDiv);

	  var compiledTemplate = Handlebars.compile(template.html());

	  var html = compiledTemplate(data);
	  $(containerDiv).html(html);
}