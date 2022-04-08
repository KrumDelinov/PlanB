"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

//Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (userId) {

    var countEl = document.getElementById("messageCount");
    var parsed = parseInt(countEl.innerText);
    parsed += 1;
    countEl.innerHTML = parsed;



});

connection
    .start();



window.addEventListener("load", function () {

    let userName = document.getElementById("userInput").innerHTML;
    console.log(userName);
    connection.invoke("SendMessageCount", userName);

});






