$(function () {

    // https://getbootstrap.com/docs/4.4/components/tooltips/
    $('[data-toggle="tooltip"]').tooltip();

    bsCustomFileInput.init();

    $("#frmSearch").submit(function (event) {

        var q = $("#q").val().trim();

        $("#q").val(q);

        if (!q) {
            event.preventDefault();
        }

    });

});