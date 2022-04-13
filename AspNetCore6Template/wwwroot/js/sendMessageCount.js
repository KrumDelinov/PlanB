document.addEventListener('DOMContentLoaded', function () {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

   

    connection.start()
        .then(function () {
            console.log('connection started');
            var userToSend = document.getElementById("userInput").innerText;
            var messageId = document.getElementById("messageId").innerHTML;
            var currentUser = document.getElementById("currentUser").innerHTML;
            connection.invoke("SendMessageCount", userToSend, messageId, currentUser)
                .catch(error => {
                    console.error(error.message);
                });

        });
});
