function lagreBestilling() {
    const pizza = {
        navn: $("#navn").val(),
        adresse: $("#adresse").val(),
        telefonnr: $("#telefonnr").val(),
        pizzaType: $("#pizzaType").val(),
        tykkelse: $("input:radio[name=tykkelse]:checked").val(),
        antall: $("#antall").val()
    };
    const url = "Pizza/SettInn";
    $.post(url, pizza, function () {
        window.location.href = "index.html";
    });
};