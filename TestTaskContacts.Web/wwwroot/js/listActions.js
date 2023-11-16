$(".updateButton").on("click", function (event) {
    let thiselem = $(this);
    let contactId = thiselem.attr("id");
    contactId = contactId.replace('update', '');
    const url = 'Contact/Edit/' + contactId;

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

$(".detailsButton").on("click", function (event) {
    let thiselem = $(this);
    let contactId = thiselem.attr("id");
    contactId = contactId.replace('details', '');
    const url = 'Contact/Details/' + contactId;

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

$(".deleteButton").on("click", function (event) {
    let thiselem = $(this);
    let contactId = thiselem.attr("id");
    contactId = contactId.replace('delete', '');
    const url = 'Contact/Delete/' + contactId;

    $.ajax({
        type: 'DELETE',
        url: url,
        success: function (data) {
            $("#listContainer").html(data);
        },
        error: function (exception) {
            console.log(exception);
        }
    });
});