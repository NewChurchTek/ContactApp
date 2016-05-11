
app.contact = function () {

    // Private members
    function bindEvents() {
        $(document).on('click', '#btn-send', send);
        $(document).on('click', '#btn-list, #btn-form', toggleView);
        $(document).on('click', '.btn-delete', remove);
        $(document).on('click', '.btn-archive', archive);
    }

    function resetForm() {
        $('#contact-form .form-control').val('');
    }

    function remove() {
        var id = $(this).attr('data-id');
        $.ajax({
            url: "/api/contact/" + id,
            type: "DELETE", 
            contentType: "application/json",
            success: function () {
                list();
            }
        });
    }

    function archive() {
        var id = $(this).attr('data-id');
        $.ajax({
            url: "/api/contact/" + id,
            type: "PUT",
            contentType: "application/json",
            success: function () {
                list();
            }
        });
    }

    function send() {
        $.post('/api/contact/create', $('#contact-form').serialize())
            .success(function (data) {
                if (data.Success) {
                    resetForm();
                    $('.messages').html('<div class="alert alert-success">Contact has been posted</div>');
                } else {
                    $('.messages').html('<div class="alert alert-danger">' + data.Message + '</div>');
                }
            })
            .error(function () {
                $('.messages').html('<div class="alert alert-danger">An unknown error occurred</div>');
            });

        return false;
    }

    function list() {
        $.get('/api/contact/get')
            .success(function (data) {
                var source = $("#list-template").html();
                var template = Handlebars.compile(source);
                $('#contact-list-container').html(template(data));
            });
    }

    function toggleView() {
        $('#contact-list, #contact-form').toggle();
        if ($('#contact-list:visible')) {
            list();
        }
    }

    return {
        // Public members
        bind: function() {
            bindEvents();
        }
    }

}();