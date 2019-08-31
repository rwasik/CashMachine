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

        var notes = getNotes(data);

        var source = document.getElementById('notes-template').innerHTML;
        var template = Handlebars.compile(source);
        var html = template({ notes: notes, errorMessage: data.errorMessage });

        $('#result').append(html);
    };

    var getNotes = function (data) {
        var notes = [];

        addNote(100, data.quantityOf100Notes, notes);
        addNote(50, data.quantityOf50Notes, notes);
        addNote(20, data.quantityOf20Notes, notes);
        addNote(10, data.quantityOf10Notes, notes);

        return notes;
    };

    var addNote = function (noteValue, quantity, collection) {
        for (let i = 0; i < quantity; i++) {
            collection.push(noteValue);
        }
    };

    var updateBtnWithdrawDisabledState = function (isDisabled) {
        $('#btnWithdraw').attr('disabled', isDisabled);
    };

    var updateSpinnerState = function (isVisible) {
        if (isVisible) {
            $('#spinner').removeClass('d-none');
        }
        else {
            $('#spinner').addClass('d-none');
        }
    };

    return {
        enhanceWithdrawBtn: enhanceWithdrawBtn
    };
}();