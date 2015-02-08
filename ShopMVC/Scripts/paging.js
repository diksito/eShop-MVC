/// <reference path="jquery-1.9.0.min.js" />

function loadProducts(page) {
    if (page < 0) {
        // do nothing
    } else {
        $("#productList").html("<h3>Loading...</h3>");
    }
}