var dropPopulate = function () {
    var passedString = $("#SearchBox").val();
    console.log("the search string is currently " + passedString);
    $.ajax({
        type: 'POST',
        url: '/Newsletter/Dropdown',
        dataType: 'json',
        data: { searchString: passedString },
        success: function (result) {
            console.log(result);
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(error);
        }
    })
}

$(document).ready(function () {
    $("#test-button").click(function () {
        var newData = $('.reader-form').serialize();
        var dataArray = (($('.reader-form').serializeArray()));
        var mailUser = {};
        mailUser.Name = dataArray[0].value;
        mailUser.Street = dataArray[1].value;
        mailUser.City = dataArray[2].value;
        mailUser.State = dataArray[3].value;
        $.ajax({
            type: 'POST',
            url: 'Newsletter/AddReader',
            datatype: 'json',
            data: mailUser,
            success: function (result) {
                console.log("Success");
                window.location.href = "";
            },
            error: function (result) {
                console.log("Fucked up");
            }
        })
    })

    $('#new-edit').submit(function (event) {
        console.log($(this).data('url-action'));
        event.preventDefault();
        var editArticle = {};
        var dataArray = (($('#new-edit').serializeArray()));
        for (let i = 0; i < dataArray.length; i++) {
            editArticle[dataArray[i].name] = dataArray[i].value;
        }
        $.ajax({
            url: $(this).data('url-action'),
            type: 'POST',
            dataType: 'json',
            data: editArticle,
            success: function (result) {
                console.log('yup');
            },
            error: function (result) {
                console.log('nope');
                console.log(result);
            }
        })
    })

    //$('#SearchBox').oninput(function () {
    //    var searchString = $("#SearchBox").val();
    //    $.ajax({
    //        type: 'GET',
    //        url: '@Url.Action("NewsletterDropdown", "Newsletter")',
    //        dataType: 'json',
    //        data: searchString,
    //        success: function (result) {
    //            console.log(result);
    //        }
    //    })
    //})

})