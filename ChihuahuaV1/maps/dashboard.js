google.charts.load('current', {'packages':['corechart', 'controls']});
google.charts.setOnLoadCallback(drawStuff);

function drawStuff() {

    var dashboard = new google.visualization.Dashboard(
      document.getElementById('programmatic_dashboard_div'));

    // We omit "var" so that programmaticSlider is visible to changeRange.
    var programmaticSlider = new google.visualization.ControlWrapper({
        'controlType': 'DateRangeFilter',
        'containerId': 'programmatic_control_div',
        'options': {
            'filterColumnLabel': 'Date',
            'ui': {'labelStacking': 'vertical'}
        }
    });

    var programmaticChart  = new google.visualization.ChartWrapper({
        'chartType': 'PieChart',
        'containerId': 'programmatic_chart_div',
        'options': {
            'width': 300,
            'height': 300,
            'legend': 'none',
            'chartArea': {'left': 15, 'top': 15, 'right': 0, 'bottom': 0},
            'pieSliceText': 'value'
        }
    });

    var data = google.visualization.arrayToDataTable([
      ['Name', 'Date'],
      ['Michael' , new Date (15,5,5)],
      ['Elisa', new Date (15,5,6)],
      ['Robert', new Date (15,5,7)],
      ['John', new Date (15,5,8)],
      ['Jessica', new Date (15,5,1)]
    ]);

    dashboard.bind(programmaticSlider, programmaticChart);
    dashboard.draw(data);

}