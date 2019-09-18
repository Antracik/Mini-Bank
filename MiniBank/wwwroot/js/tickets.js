

$(document).on('click', '.js-get-ticket', function () {
    var id = $(this.closest('tr')).attr('data-ticket');

    $.ajax({
        type: 'GET',
        url: '/Support/GetTicketDetails/' + id,
        success: function (result) {
            console.log(result);
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