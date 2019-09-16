// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function render30DaysChart(jsonIn, chartEelement) {
    var json = jsonIn;

    var labels = [];
    var data = [];

    for (var i = 0; i < json.length; i++) {
        labels.push("Day " + json[i].Day);
        data.push(json[i].UserCount);
    }

    new Chart(chartEelement, {
        "type": "bar",
        "data": {
            "labels": labels,
            "datasets": [{
                "label": "New Users",
                "data": data,
                "fill": true,
                "backgroundColor": "rgba(0,0,255,0.2)",
                "borderColor": "rgba(255, 99, 132)",
                "borderWidth": 1
            }]
        },
        "options": {
            "scales": {
                "yAxes": [{
                    "ticks": {
                        "beginAtZero": true
                    }
                }]
            },
            "legend": { "display": false },
            title: {
                display: true,
                text: 'New users for the past 30 days'
            }
        }
    });
}

function renderTotalMoneyCurrency(jsonIn, chartElement) {
    var json = jsonIn;

    var labels = [];
    var data = [];
    var colors = [];

    for (var i = 0; i < json.length; i++)
    {
        labels.push(json[i].Currency);
        data.push(json[i].Total);
        colors.push(getRandomColor());
    }

    new Chart(chartElement, {
        "type": "pie",
        "data": {
            "labels": labels,
            "datasets": [{
                "data": data,
                "fill": true,
                "backgroundColor": colors
            }]
        },
        "options": {
            //responsive : true,
            title: {
                display: true,
                text: 'Total Money By Currency'
            }
        }
    });
}

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}