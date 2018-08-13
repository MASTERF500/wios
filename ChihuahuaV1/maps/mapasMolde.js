
//<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?language=fra&amp;sensor=false"></script> 
//<script type="text/javascript">
var map;
var Markers = {};
var infowindow;
var markers = JSON.parse(' <%=x%> ');
//var origin = new google.maps.LatLng(28.4816887, -106.1341949);

function initialize() {
    var mapOptions = {zoom: 13, center: origin};
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 28.4816887, lng: -106.1341949 }
    });
    infowindow = new google.maps.InfoWindow();

    for(i=0; i<locations.length; i++) {
        var position = new google.maps.LatLng(locations[i][6], locations[i][7]);
        var marker = new google.maps.Marker({
            position: position,
            map: map,
        });
        google.maps.event.addListener(marker, 'click', (function(marker, i) {
            return function () {
                var contenidoLabel = "<div> <h2>ID: " + lacation[i][0] + "</h2><p>Nombre: " + lacation[i][2] + " Latitud: " + lacation[i][6] + ", Longitud: " + lacation[i][7] + ", Altitud: " + lacation[i][8] + ", Inicio: " + lacation[i][10] + "  </p>  <a href=''> Información...</a> </div>";
                infowindow.setContent(contenidoLabel);
                infowindow.setOptions({maxWidth: 200});
                infowindow.open(map, marker);
            }
        }) (marker, i));
        Markers[locations[i][0]] = marker;
    }

    locate(0);

}

function locate(marker_id) {
    var myMarker = Markers[marker_id];
    var markerPosition = myMarker.getPosition();
    map.setCenter(markerPosition);
    google.maps.event.trigger(myMarker, 'click');
}

google.maps.event.addDomListener(window, 'load', initialize);

//</script>