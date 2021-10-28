"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Hub").build();

document.getElementById("dugme").addEventListener("submit", function (event) {
    connection.invoke("PrimiNovTerminMusterija",@Model.s)
});

