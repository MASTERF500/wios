using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
//agregadas
using SistemaAlertas.Business;
using SistemaAlertas.Entity;
namespace ChihuahuaV1.maps
{
    public class MakeGoogleMaps
    {
        public string mapa(int idedo) {
            List<Estacion> lisEstaciones = new List<Estacion>();
            lisEstaciones = Estacion.GetEstaciones(idedo);
            string datos = "";
            foreach (Estacion row in lisEstaciones) {
                datos = datos + " [a:'"+row.Numero+"',b:'"+row.Nombre+"',c:'"+row.Latitud+"',d:'"+row.Longitud+"',e:'?est="+row.Numero+"'], ";
            }
            string mapa = @"<script type='text/javascript'>
            function initMap() {
                var map = new google.maps.Map(document.getElementById('map'), {
                  zoom: 3,
                  center: {lat: -28.024, lng: 140.887}
                });
                var markers = locations.map(function(info, i) {
                  return new google.maps.Marker({
                    position: {lat:La,lng:Ln},
                    label: ,
                    
                  });
                });

                // Add a marker clusterer to manage the markers.
                var markerCluster = new MarkerClusterer(map, markers,
                    {imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m'});}
              
                var info = [ "+datos+" ] "+
                @"google.maps.event.addListener(marker, 'click', function() {
                    window.location.href = this.url;
                });
            </script>
            <script src='https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js'> </script>
            <script async defer src='https://maps.googleapis.com/maps/api/js?key=AIzaSyAmZCnSJBCnBrJ2V70CIbX27A0yFl-06A0&callback=initMap'> </script>";
            return mapa;
        }
    
    }
}