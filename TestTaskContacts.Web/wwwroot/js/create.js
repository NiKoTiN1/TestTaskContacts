$.validator.addMethod(
    "regex",
    function (value, element, regexp) {
        var re = new RegExp(regexp);
        return this.optional(element) || re.test(value);
    },
    "Please check your input."
);

$.validator.addMethod("beforeCurrentDate", function (value, element) {
    var currentDate = new Date();
    var inputDate = new Date(value);

    return inputDate < currentDate;
}, "Please enter a date before today's date.");

$("#modalTitle").text("Create contact");

$("#modalForm").validate({
    rules: {
        name: {
            required: true,
            maxlength: 100,
            minlength: 5,
        },
        phone: {
            required: true,
            minlength: 4,
            maxlength: 12,
            regex: "^\\+\\d{4,12}$"
        },
        jobTitle: {
            required: true,
            maxlength: 100,
        },
        birthDate: {
            required: true,
            beforeCurrentDate: true,
        }
    },
    messages: {
        name: {
            required: "Name field is required",
            minlength: "Name length should be greater than {0}",
            maxlength: jQuery.validator.format("Name length should be less than {0}")
        },
        phone: {
            required: "Phone field is required",
            minlength: "Phone length should be greater than {0}",
            maxlength: jQuery.validator.format("Phone length should be less than {0}")
        },
        jobTitle: {
            required: "JobTitle field is required",
            maxlength: jQuery.validator.format("JobTitle length should be less than {0}")
        },
        birthDate: {
            required: "BirthDate field is required",
            maxlength: jQuery.validator.format("BirthDate length should be less than {0}")
        }
    },
    submitHandler: function (form) {
        let formData = $('#modalForm').serializeArray();
        console.log("test");
        $.ajax({
            type: 'POST',
            url: 'Contact/Create',
            data: formData,
            success: function (data) {
                $("#listContainer").html(data);
                $("#modalCenter").empty();
                $('#modalCenter').modal('toggle');
            },
            error: function (exception) {
                console.log(exception);
            }
        });
        return false;
    }
});