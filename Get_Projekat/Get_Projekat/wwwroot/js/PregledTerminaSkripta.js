"use strict";


var connection = new signalR.HubConnectionBuilder().withUrl("/Hub").build();


connection.start();

connection.on("NovTerminMusterija", function (message) {

    var li = document.createElement("li")

    var t = document.getElementById("tabela");
    t.appendChild(li);
    li.textContent = ' says aca}';
    console.log('cao')
});



