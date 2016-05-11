
app.clock = function () {

    // Private members
    function bindEvents() {
        setInterval(display, 1000);
    }

    function display() {

        var currentTime = new Date();
        var ampm = "AM";
        var h = currentTime.getHours();
        var m = currentTime.getMinutes();
        var s = currentTime.getSeconds();

        if (h == 0) {
            h = 12;
        } else if (h > 12) {
            h = h - 12;
            ampm = "PM";
        }
        if (m < 10) {
            m = "0" + m;
        }
        if (s < 10) {
            s = "0" + s;
        }
        $('#the-time').html(h + ':' + m + ':' + s + ' ' + ampm);
    }

    return {
        // Public members
        bind: function() {
            bindEvents();
        }
    }

}();