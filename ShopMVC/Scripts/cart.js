/// <reference path="jquery-1.9.0.min.js" />

function addToBasket(productId, qty) {

    var jqxhr = $.post("/Cart/Add", { productId: productId, qty: qty }, function (data) {
        if (data.status == true) {
            updateBasketCounter(data.qty); // update counter
        } else {
            alert("Failed to add this item to basket");
        }
    })
    .fail(function () {
        alert("Error");
    });
}

function updateBasketCounter(count) {
    if (count < 0) {
        $("#cartCounter").html(0);
    } else {
        $("#cartCounter").html(count);
    }
}