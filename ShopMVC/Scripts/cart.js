﻿/// <reference path="jquery-1.9.0.min.js" />

function addToBasket(productId, qty) {

    var jqxhr = $.post("http://localhost:29139/api/Shop", { productId: productId, quantity: qty }, function (data) {
        console.log(data);
        if (data.Status == true) {
            updateBasketCounter(data.Quantity); // update counter
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