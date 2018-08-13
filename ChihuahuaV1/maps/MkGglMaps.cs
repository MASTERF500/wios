using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
//agregadas
using SistemaAlertas.Business;
using SistemaAlertas.Entity;
using System.Web.Script.Serialization;
namespace ChihuahuaV1.maps
{
    public class MkGglMaps
    {
        public string mapa(int idedo)
        {
            List<Estacion> lisEstaciones = new List<Estacion>();
            lisEstaciones = Estacion.GetEstaciones(idedo);
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            string serializado = serializador.Serialize(lisEstaciones);
            string mapa = @"<script type='text/javascript'> var info = " + serializado+"; " +
                @"function initMap() {
                var map = new google.maps.Map(document.getElementById('map'), {
                  zoom: 3,
                  center: {lat: 28.4816887, lng: -106.1341949}
                });

                for (i = 0; i < info.length; i++) {
                    var data = info[i]
                    var contenidoLabel ='<div> <h2> </h2>  <a href=''>Información...</a> </div>';
                    var infowindow = new google.maps.InfoWindow({content: contenidoLabel});
                    var latlong = new google.maps.LatLng(data.Latitud, data.Longitud);
                    var marker = new google.maps.Marker({ position: latlong,map: map,title: data.Numero});
                    marker.addListener('click', function() { infowindow.open(map, marker); });
                }
                var markerCluster = new MarkerClusterer(map, markers,{imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m'});}
                google.maps.event.addListener(marker, 'click', function() {window.location.href = this.url;});

            </script>
            <script src='https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js'> </script>
            <script async defer src='https://maps.googleapis.com/maps/api/js?key=AIzaSyAmZCnSJBCnBrJ2V70CIbX27A0yFl-06A0&callback=initMap'> </script>";
            return mapa;
            //{"Numero":22,"Idred":1,"Nombre":"Granja Elsa","EstadoId":1,"MunicipioId":1,"Productor":"Teodoro Olivares Ventura","Latitud":21.7853,"Longitud":-102.263885,"Altitud":1913,"Inicio":"2013-09-06T05:00:00Z","InicioParseo":"6/9/2013"}
        }
    }
}