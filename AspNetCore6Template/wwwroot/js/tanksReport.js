




function drawChart(view) {

    
    
}

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();
connection.on("Notify", function (view) {
    google.charts.load('current', { 'packages': ['gauge'] });
    google.charts.setOnLoadCallback(drawChart);
    view.forEach(element => {
        var data = google.visualization.arrayToDataTable([
            ['Label', 'Value'],
            [element.name, element.amount]
        ]);

        var options = {
            width: 250, height: 150,
            max: 1200,
            redFrom: 750, redTo: 1200,
            yellowFrom: 500, yellowTo: 750,
            minorTicks: 5
        };

        var chart = new google.visualization.Gauge(document.getElementById(element.name));
        chart.draw(data, options);


    });


});
connection.start();