
var app = app || {};

app.runner = function () {

    return {
        start: function () {
            // initialize all forms
            app.contact.bind();
            app.clock.bind();
        }
    }

}();