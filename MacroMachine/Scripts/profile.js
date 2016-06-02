$(document).ready(function () {
    $("#Birthday").datepicker({
        startView: 2
    });

    var metric = $("#Metric").val();

    if (metric === "True") {
        $("#dvMetric").removeClass("hide");
        $("#dvImperial").addClass("hide");
    } else if (metric === "False") {
        $("#dvMetric").addClass("hide");
        $("#dvImperial").removeClass("hide");
    }

    //onchange for radio, hide/swap visibility...move the hiding to a function
});
