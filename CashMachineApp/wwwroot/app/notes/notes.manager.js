'use strict';

var notesManager = function () {

    var enhanceWithdrawBtn = function () {
        $('#btnWithdraw').click(function () {

            $('#result').empty();

            updateBtnWithdrawDisabledState(true);
            updateSpinnerState(true);

            var amount = $('#txtAmount').val();
            notesService.getNotesQuantity(amount, displayNotesInfo);
        });
    };

    var displayNotesInfo = function (data) {
        updateBtnWithdrawDisabledState(false);
        updateSpinnerState(false);

        var source = document.getElementById('notes-template').innerHTML;
        var template = Handlebars.compile(source);
        var html = template(data);

        $('#result').append(html);
    };

    var updateBtnWithdrawDisabledState = function (isDisabled) {
        $('#btnWithdraw').attr('disabled', isDisabled);
    }

    var updateSpinnerState = function (isVisible) {
        if (isVisible) {
            $('#spinner').removeClass('d-none');
        }
        else {
            $('#spinner').addClass('d-none');
        }
    }

    return {
        enhanceWithdrawBtn: enhanceWithdrawBtn
    };
}();