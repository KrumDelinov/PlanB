document.addEventListener('DOMContentLoaded', function () {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

    connection.on("ReceiveMessage", function (userFullName, messageId) {

        var countEl = document.getElementById("messageCount");
        var messageIdInt = parseInt(messageId);
        var parsedCount = parseInt(countEl.innerText);
        parsedCount += 1;
        countEl.innerHTML = parsedCount;

        var dropDownDiv = document.getElementById("messageDropdown");

        var anchor = document.createElement('a');
        anchor.setAttribute('class', 'dropdown-item d-flex align-items-center');
        anchor.setAttribute('href', '/Employee/Home/ReadMessage/' + messageIdInt)
        var massageDiv = document.createElement('div');
        massageDiv.setAttribute('class', 'font-weight-bold');
        var textDiv = document.createElement('div');
        textDiv.setAttribute('class', 'text-truncate');
        textDiv.innerHTML = 'New message from'
        var userNameDiv = document.createElement('div');
        userNameDiv.setAttribute('class', 'small text-gray-500');
        userNameDiv.innerHTML = userFullName;

        massageDiv.appendChild(textDiv);
        massageDiv.appendChild(userNameDiv);
        anchor.appendChild(massageDiv);

        

        dropDownDiv.appendChild(anchor);

    });

    connection.start();
});