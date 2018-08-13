<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ChihuahuaV1.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?language=fra&amp;sensor=false"></script> 

    <div id="map" style="width: auto; height: 500px;"></div>
    <script type='text/javascript'>
        var map;
        var Markers = {};
        var infowindow;
        var locations = JSON.parse(' <%=x%> ');

        function initMap() {
            var mapOptions = { zoom: 10, center: origin };
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 7,
                center: { lat: 28.4816887, lng: -106.1341949 }
            });
            infowindow = new google.maps.InfoWindow();

            for (i = 0; i < locations.length; i++) {
                var position = new google.maps.LatLng(locations[i].Latitud, locations[i].Longitud);
                var marker = new google.maps.Marker({
                    position: position,
                    map: map,
                });
                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        var contenidoLabel = "<div> <h2>ID: " + locations[i].Numero + "</h2><p><b>Nombre:</b> " + locations[i].Nombre + "<br><b>Latitud</b>: " + locations[i].Latitud + "<br><b>Longitud:</b> " + locations[i].Longitud + "<br><b>Altitud:</b> " + locations[i].Altitud + "<br><b>Inicio:</b> " + locations[i].InicioParseo + "  </p>  <a href='Contact.aspx?id="+locations[i].Numero+"'> Información...</a> </div>";
                        infowindow.setContent(contenidoLabel);
                        infowindow.setOptions({ maxWidth: 200 });
                        infowindow.open(map, marker);
                    }
                })(marker, i));
                Markers[locations[i].Numero] = marker;
            }

            locate(0);

        }

        function locate(marker_id) {
            var myMarker = Markers[marker_id];
            var markerPosition = myMarker.getPosition();
            map.setCenter(markerPosition);
            google.maps.event.trigger(myMarker, 'click');
        }

        //google.maps.event.addDomListener(window, 'load', initMap);
    </script>
  
    <%--<script src='https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js'> </script>--%>
    <script async defer
        src='https://maps.googleapis.com/maps/api/js?key=AIzaSyAmZCnSJBCnBrJ2V70CIbX27A0yFl-06A0&callback=initMap'>
    </script>



</asp:Content>
