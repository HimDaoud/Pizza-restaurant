$(function () {
    $.get("pizza/HentAlle", function (bestillinger) {
        formaterBestillinger(bestillinger);
    });
});

function formaterBestillinger(bestillinger) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Adresse</th><th>Telefonnr</th><th>PizzaType</th>" +
        "<th>Tykkelse</th><th>Antall</th>" +
        "</tr>";
    for (let bestilling of bestillinger) {
        ut += "<tr>" +
            "<td>" + bestilling.navn + "</td>" +
            "<td>" + bestilling.adresse + "</td>" +
            "<td>" + bestilling.telefonnr + "</td>" +
            "<td>" + bestilling.pizzaType + "</td>" +
            "<td>" + bestilling.tykkelse + "</td>" +
            "<td>" + bestilling.antall + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#bestillinger").html(ut);
}