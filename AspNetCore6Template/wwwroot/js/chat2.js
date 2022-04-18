"use strict";



var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

//Disable the send button until connection is established.
document.getElementById("sendChat").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var message = document.getElementById("chatInput");
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message.value}`;
    message.value = '';
});

connection.start().then(function () {
    document.getElementById("sendChat").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendChat").addEventListener("click", function (event) {
    var userNameFrom = document.getElementById("currentUser").textContent;
    
    var message = document.getElementById("chatInput").value;
    connection.invoke("Send", userNameFrom, escape(message)).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}
