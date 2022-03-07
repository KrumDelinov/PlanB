"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();


connection.start();
connection.on("ReceiveMessage", function (userId) {

    var user = userId;


    var countEl = document.getElementById("messageCount");
    var parsed = parseInt(countEl.innerText);
    parsed += 1;
    countEl.innerHTML = parsed;

});





function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}
