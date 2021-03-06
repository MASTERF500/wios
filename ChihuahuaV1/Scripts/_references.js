/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery-ui-1.8.20.js" />
/// <reference path="modernizr-2.5.3.js" />
var chart1 = new CanvasJS.Chart('chart1',
                    {
                        animationEnabled: true,
                        title: { text: 'UNIDADES CALOR ACUMULADAS (HORAS DÍA)' },
                        axisY: {
                            interval: 10,
                            maximum: 50,
                            title: 'UC (Tmax - Tmin / 2 - 3.3)',
                            gridThickness: 0,
                            stripLines: [
                                { value: 75, label: 'PM10: 75µg/m3', labelFontColor: 'black', color: 'red' },
                                { value: 45, label: 'PM2.5: 45µg/m3', labelFontColor: 'black', color: 'red' }
                            ]
                        },
                        axisX: {
                            interval: 1, maximun: 24,
                            labelAngle: -50,
                            stripLines: [
                                { value: new Date(" + fch.Year + ", " + fch.Month + ", " + fch.Day + ", 06), lineDashType: 'dot', label: '▲ 6 a.m.', color: 'red', labelFontColor: 'black' },
                                { value: new Date(" + fch.Year + ", " + fch.Month + ", " + fch.Day + ", 12), lineDashType: 'dot', label: '▲ 12 p.m.', color: 'red', labelFontColor: 'black' },
                                { value: new Date(" + fch.Year + ", " + fch.Month + ", " + fch.Day + ", 18), lineDashType: 'dot', label: '▲ 6 P.M.', color: 'red', labelFontColor: 'black' }
                            ]
                        },
                        data: [
                        { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm tt', showInLegend: true, name: 'PM1', type: 'line', dataPoints: [" + pm1D + "] },
                        { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm TT', showInLegend: true, name: 'PM2.5', type: 'line', dataPoints: [" + pm2p5D + "] },
                        { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm TT', showInLegend: true, name: 'PM10', type: 'line', dataPoints: [" + pm10D + "] }
                        ]
                    });
chart1.render();