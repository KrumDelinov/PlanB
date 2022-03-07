"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

connection.on("ReceiveMessage", function (userId) {

    var user = userId;


    var countEl = document.getElementById("messageCount");
    var parsed = parseInt(countEl.innerText);
    parsed += 1;
    countEl.innerHTML = parsed;
    

});
connection.start().then(function () {
    var user = document.getElementById("userInput").innerText;
    connection.invoke("SendMessage", user);
 
    
});



function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}
