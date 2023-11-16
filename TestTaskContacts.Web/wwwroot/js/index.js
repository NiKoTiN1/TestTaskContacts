$("#createButton").on("click", function (event) {
    const url = 'Contact/Create';

    $.ajax({
        type: 'GET',
        url: url,
        success: function (data) {
            $("#modalContainer").html(data);
            $('#modalCenter').modal('toggle');
        },
        error: function (exception) {
            console.log(exception);
        }
    });
});