'use strict';

var notesService = function () {

    var apiUrl = "https://localhost:44328/api";

    var getNotesQuantity = function (amount, callbackFunc) {
        $.ajax({
            type: "GET",
            url: apiUrl + "/notes/GetNotesQuantity?amount=" + amount,
            dataType: "json",
            success: function (data) {
                callbackFunc(data)
            },
            error: function () {
                window.location.href = "home/error";
            }
        });
    };

    return {
        getNotesQuantity: getNotesQuantity
    };
}();