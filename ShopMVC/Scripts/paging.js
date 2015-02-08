/// <reference path="jquery-1.9.0.min.js" />

function loadProducts(page) {
    if (page > -1){
        $("#productList").html("<h3 align='center'>Loading...</h3>");

        // get products
        var jqxhr = $.post("/Cart/GetProducts", { page: page }, function (data) {

            $("#productList").html("");
            // iterate over and apply this template
            $.each(data.products, function (i, item) {
                $("#productList").append('<div class="col-sm-4 col-md-3"><div class="thumbnail">'
                    + '<img src="data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/PjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iMjQyIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDI0MiAyMDAiIHByZXNlcnZlQXNwZWN0UmF0aW89Im5vbmUiPjxkZWZzLz48cmVjdCB3aWR0aD0iMjQyIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI0VFRUVFRSIvPjxnPjx0ZXh0IHg9IjkxLjUiIHk9IjEwMCIgc3R5bGU9ImZpbGw6I0FBQUFBQTtmb250LXdlaWdodDpib2xkO2ZvbnQtZmFtaWx5OkFyaWFsLCBIZWx2ZXRpY2EsIE9wZW4gU2Fucywgc2Fucy1zZXJpZiwgbW9ub3NwYWNlO2ZvbnQtc2l6ZToxMXB0O2RvbWluYW50LWJhc2VsaW5lOmNlbnRyYWwiPjI0MngyMDA8L3RleHQ+PC9nPjwvc3ZnPg==" alt="Product" data-holder-rendered="true">'
                    + '<div class="caption">'
                        + '<h3>' + data.products[i].Title + '</h3>'
                        + '<p>' + data.products[i].Description + '</p>'
                        + '<p><a href="/Product/Index/' + data.products[i].ProductId + '" class="btn btn-default">Buy</a></p>'
                    + '</div>'
                + '</div></div>');
            });
        })
        .fail(function () {
            $("#productList").append("<h3 align='center'>Error: could not load articles</h3>");
        });
    }
}