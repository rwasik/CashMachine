Handlebars.registerHelper('notesResult', function (items, options) {
    return options.fn(items.join(', '));
});