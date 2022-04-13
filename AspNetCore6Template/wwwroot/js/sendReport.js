"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

//Disable the send button until connection is established.
document.getElementById("smallCup").style.pointerEvents = "none";
document.getElementById("bigCup").style.pointerEvents = "none";

connection.on("ReceiveReport", function (userFullName, btchType) {
    var li = document.createElement("tr");
    
    var trName = document.createElement("td");
    trName.textContent = userFullName;
    var trType = document.createElement("td");
    trType.innerHTML = btchType;

    li.appendChild(trName);
    li.appendChild(trType);

    var tb = document.getElementById('tableBody');

    tb.appendChild(li);

   

});

connection.start().then(function () {
    console.log("Start")
    document.getElementById("smallCup").style.pointerEvents = "auto";
    document.getElementById("bigCup").style.pointerEvents = "auto";
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("smallCup").addEventListener("click", function (event) {
    var userNameFrom = document.getElementById("currentUser").innerHTML;
    connection.invoke("SendReportAsync", userNameFrom).catch(function (err) {

        return console.error(err.toString());
    });
    event.preventDefault();
});




