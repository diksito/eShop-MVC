/// <reference path="jquery-1.9.0.min.js" />

function addToBasket(productId, qty) {

    var jqxhr = $.post("/api/ShoppingCart", { productId: productId, qty: qty }, function () {
        console.log("ProductId: " + productId + " " + qty);
        alert("success");
    })
    .done(function () {
        alert("second success");
    })
    .fail(function () {
        alert("error");
    })
    .always(function () {
        alert("finished");
    });
}