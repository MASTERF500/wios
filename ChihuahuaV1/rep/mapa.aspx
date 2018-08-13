<%@ Page Title="" Language="C#" MasterPageFile="~/rep/Demon.Master" AutoEventWireup="true" CodeBehind="mapa.aspx.cs" Inherits="ChihuahuaV1.rep.mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- References --%>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?language=fra&amp;sensor=false"></script> 
    <%-- ReferencesEnd --%>

    <%--  --%>

    <%-- MapDiv --%>
        <div id="map" style="width: auto; height: 500px;"></div>
    <%-- MapdivEnd --%>

    <%-- mapMarkersScript --%>
        <script type='text/javascript'>
        var map;
        var Markers = {};
        var infowindow;
        var locations = JSON.parse(' <%=estaciones%> ');

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
                            var contenidoLabel = "<div> <h2>ID: " + locations[i].Numero + "</h2><p><b>Nombre:</b> " + locations[i].Nombre + "<br><b>Latitud</b>: " + locations[i].Latitud + "<br><b>Longitud:</b> " + locations[i].Longitud + "<br><b>Altitud:</b> " + locations[i].Altitud + "<br><b>Inicio:</b> " + locations[i].InicioParseo + "  </p>  <a href='datos.aspx?id=" + locations[i].Numero + "&nom=" + locations[i].Nombre + "&lat=" + locations[i].Latitud + "&lon=" + locations[i].Longitud + "'> Información...</a> </div>";
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
    </script>
    <%-- mapMarkersScriptEnd --%>



    <%-- googleMapsKey --%>
    <script async defer src='https://maps.googleapis.com/maps/api/js?key=AIzaSyAmZCnSJBCnBrJ2V70CIbX27A0yFl-06A0&callback=initMap'></script>
    <%-- googleMapsKeyEnd --%>
</asp:Content>
