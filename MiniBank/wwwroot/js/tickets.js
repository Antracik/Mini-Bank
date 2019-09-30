$(document).on('click', '.js-get-ticket', function () {
    var id = $(this.closest('tr')).attr('data-ticket');

    $.ajax({
        type: 'GET',
        url: '/Support/GetTicketDetails/' + id,
        success: function (result) {
            loadTicketDetailsModal(result);
        },
        error: function () {
            $.notify("Error getting details...", "error");
        }
    });
});

function loadTicketDetailsModal(json) {
    var title = json.title;
    var description = json.description;
    var ticketType = json.ticketType;
    var ticketStatus = json.ticketStatus;

    var date = new Date(json.dateCreated);
    var time = date.toTimeString();
    time = time.substring(0, time.indexOf(' '));

    var dateFormatted = date.toDateString() + " " + time;

    var elements = $('.js-set-ticket-details').children('.js-set-ticket-details-data');

    elements[0].innerHTML = title;
    elements[1].innerHTML = ticketType;
    elements[2].innerHTML = ticketStatus;
    elements[3].innerHTML = dateFormatted;
    elements[4].innerHTML = description;
}


let pageIndex = 0;
let ticketId = 0;

function renderMessages(messages) {
    for (var i = 0; i < messages.length; i++) {
        var newMessage = "<li> On " + messages[i].date + " ";
        newMessage += messages[i].userName + " says: " + messages[i].message + " </li>";
        $('.js-message-content').val("");
        $("#message-list").prepend(newMessage)
    }
}

$('#show-more').on('click', function (e) {
    var id = ticketId;
    var button = $(this);

    button.text("Loading...");
    button.disabled = true;

    $.ajax({
        type: 'GET',
        url: '/Support/GetMessages/' + pageIndex + '/' + id,
        success: function (result) {
            pageIndex += 1;
            button.text("Show More");
            renderMessages(result);
            button.disabled = true;
        },
        error: function () {
            button.text("Show More");
            $.notify("No more messages...", "info");
            button.disabled = true;
        }
    });
});

$('#Ticket-Messages').on('hidden.bs.modal', function () {
    $('#message-list').empty();
    pageIndex = 0;
});

$('#Ticket-Messages').on('show.bs.modal', function (e) {
    var id = $(e.relatedTarget.closest('tr')).attr('data-ticket');
    ticketId = id;
    $('#hidden-Id').val(id);

    $.ajax({
        type: 'GET',
        url: '/Support/GetMessages/' + pageIndex + '/' + id,
        success: function (result) {
            renderMessages(result);
            pageIndex += 1;
        },
        error: function () {
            $.notify("No messages to show", "info");
        }
    });
});

$('.js-send-message').on('click', function (e) {
    e.preventDefault();

    var tdEl = getTicketStatusElement(ticketId);

    if (tdEl.html().trim().toLowerCase() === 'closed') {
        $.notify("Ticket is closed, cannot send messages", 'info');
        return;
    }

    var message = $('.js-message-content').val();

    if (!message.trim()) {
        $.notify("Message cannot be empty!", 'error');
        return;
    }

    var button = this;

    button.disabled = true;

    $.ajax({
        type: 'POST',
        url: '/Support/SendMessage/' + ticketId + '/' + message,
        success: function (result) {
            if (result.status.toLowerCase() === "success") {
                var newMessage = "<li> On " + result.date + " ";
                newMessage += result.userName + " says: " + result.message + " </li>";
                $('.js-message-content').val("");
                $("#message-list").prepend(newMessage)  
                button.disabled = false;
            }
            else {
                button.disabled = false;

                $.notify(result.reason, result.status);
            }
        },
    });

});

function getTicketStatusElement(ticketId) {
    return $(`tr[data-ticket='${ticketId}']`).children('.js-ticket-status');
}

$('.js-close-ticket').on('click', function () {
    var tdElement = getTicketStatusElement(ticketId);
    var button = this;

    if (tdElement.html().trim().toLowerCase() === 'open') {

        button.disabled = true;

        $.ajax({
            type: 'POST',
            url: '/Support/CloseTicket/' + ticketId,
            success: function (result) {
                if (result.status.toLowerCase() === "success") {
                    button.disabled = false;
                    tdElement.html('Closed');
                    $.notify("Successfuly marked ticket as closed!", 'success');
                }
                else {
                    button.disabled = false;
                    $.notify(result.reason, result.status);
                }
            },
        });
    }
    else {
        $.notify('Ticket is already marked as closed!', 'info');
    }
});

$('#Ticket-Close').on('show.bs.modal', function (e) {
    var id = $(e.relatedTarget.closest('tr')).attr('data-ticket');
    ticketId = id;
});