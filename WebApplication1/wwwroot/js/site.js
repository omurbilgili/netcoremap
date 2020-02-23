// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
mapboxgl.accessToken = 'pk.eyJ1Ijoib211cmJpbGdpbGkiLCJhIjoiY2s2d2puZnltMGM4djNtcDdpb3l1YnNpMyJ9.ETTdXxuhVY-BCY4B-IcpYg';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/outdoors-v11',
    center: [34.826660, 39.351290],
    zoom: 5
});

function generateGeometry(type, callback) {
    $.ajax({
        type: "POST",
        url: "/api/GenerateGeometry",
        data: JSON.stringify({ "type": type }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //console.log(data);
            callback(data);

        },
        failure: function (errMsg) {
            alert(errMsg);
        }
    });
}


//callback
$(document).on('keypress', function (e) {
    switch (e.key.toLowerCase()) {
        case "e":
            generateGeometry("Ellipse", function (data) {
                var timestamp = Date.now();
                map.addSource(data.type + timestamp, data.geojson);
                map.addLayer({
                    'id': data.type + timestamp,
                    'type': 'fill',
                    'source': data.type + timestamp,
                    'layout': {},
                    'paint': {
                        'fill-color': data.fillColor,
                        'fill-opacity': 1,
                        'fill-outline-color': data.lineColor
                    }
                });
            });
            break;
        case "c":
            generateGeometry("Circle", function (data) {
                var timestamp = Date.now();
                map.addSource(data.type + timestamp, data.geojson);
                map.addLayer({
                    'id': data.type + timestamp,
                    'type': 'fill',
                    'source': data.type + timestamp,
                    'layout': {},
                    'paint': {
                        'fill-color': data.fillColor,
                        'fill-opacity': 1,
                        'fill-outline-color': data.lineColor
                    }
                });
            });
            break;
        case "s":
            generateGeometry("Square", function (data) {
                var timestamp = Date.now();
                map.addSource(data.type + timestamp, data.geojson);
                map.addLayer({
                    'id': data.type + timestamp,
                    'type': 'fill',
                    'source': data.type + timestamp,
                    'layout': {},
                    'paint': {
                        'fill-color': data.fillColor,
                        'fill-opacity': 1,
                        'fill-outline-color': data.lineColor
                    }
                });
            });
            break;
        case "t":
            generateGeometry("Triangle", function (data) {
                var timestamp = Date.now();
                map.addSource(data.type + timestamp, data.geojson);
                map.addLayer({
                    'id': data.type + timestamp,
                    'type': 'fill',
                    'source': data.type + timestamp,
                    'layout': {},
                    'paint': {
                        'fill-color': data.fillColor,
                        'fill-opacity': 1,
                        'fill-outline-color': data.lineColor
                    }
                });
            });
            break;
        default:
            generateGeometry("", function (data) {
                var timestamp = Date.now();
                map.addSource(data.type + timestamp, data.geojson);
                map.addLayer({
                    'id': data.type + timestamp,
                    'type': 'fill',
                    'source': data.type + timestamp,
                    'layout': {},
                    'paint': {
                        'fill-color': data.fillColor,
                        'fill-opacity': 1,
                        'fill-outline-color': data.lineColor
                    }
                });
            });
            break;
    }
});