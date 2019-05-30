// // mapboxgl.accessToken = 'pk.eyJ1IjoibXlsaW5kZW4iLCJhIjoiY2p2emk1MXZoMDBreTN6bWZ4NTlxMmsxciJ9.jda2L9BLiahcaIA0vrbtpQ';
// // var map = new mapboxgl.Map({
// // 	container: 'myMap',
// // 	style: 'mapbox://styles/mapbox/streets-v11'
// // });
// mapboxgl.accessToken = 'token';
document.addEventListener('DOMContentLoaded', () => {

    let setSel = async (items) => {
        // const elTasks1 = document.getElementById("v");

        const elTasks = document.getElementById("list");
        // elTasks.innerHTML = "";

        var objSel1 = document.getElementById("selFirstPlace");
        var objSel2 = document.getElementById("selSecondPlace");

        var i = 0;
        items.forEach(el => {
            const divEl = document.createElement("div");
            divEl.id = el.id;

            divEl.innerHTML =
                '<p class="city"> ' +
                el.name + "</p>" +
                '<p class="address"> ' +
                el.address + ", " + el.postalCode + "</p>" +
                // '<img class="" src="' + el.photo + '">' +
                '<p class="coordinate"> Coordinates:' +
                el.geometry.x.toFixed(2) + '; ' + el.geometry.y.toFixed(2) + "</p>"

            // + '<p><a href="' +
            // el.link + '">' + "Go to site" + "</a></p>"
            ;
            elTasks.appendChild(divEl);

            // elTasks1.appendChild(divEl);

            objSel1.options[i] = new Option(el.name, el.id);
            objSel2.options[i] = new Option(el.name, el.id);
            i++;
        });
    }
    
    var features = [];

    let setMap = async (res) => {


        res.forEach(item => {
            features.push({
                "type": "Feature",
                "properties": {
                    "name": item.name,
                    "address": item.address,
                    "photo": item.photo,
                    "postalCode": item.postalCode,
                    "description": item.description
                },
                "geometry": {
                    "type": "Point",
                    "coordinates": [
                        item.geometry.x,
                        item.geometry.y,
                    ]
                }
            });
        });

        var size = 100;

        var pulsingDot = {
            width: size,
            height: size,
            data: new Uint8Array(size * size * 4),

            onAdd: function () {
                var canvas = document.createElement('canvas');
                canvas.width = this.width;
                canvas.height = this.height;
                this.context = canvas.getContext('2d');
            },

            render: function () {
                var duration = 1000;
                var t = (performance.now() % duration) / duration;

                var radius = size / 2 * 0.3;
                var outerRadius = size / 2 * 0.7 * t + radius;
                var context = this.context;

                // draw outer circle
                context.clearRect(0, 0, this.width, this.height);
                context.beginPath();
                context.arc(this.width / 2, this.height / 2, outerRadius, 0, Math.PI * 2);
                context.fillStyle = 'rgba(255, 200, 200,' + (1 - t) + ')';
                context.fill();

                // draw inner circle
                context.beginPath();
                context.arc(this.width / 2, this.height / 2, radius, 0, Math.PI * 2);
                context.fillStyle = 'rgba(255, 100, 100, 1)';
                context.strokeStyle = 'white';
                context.lineWidth = 2 + 4 * (1 - t);
                context.fill();
                context.stroke();

                // update this image's data with data from the canvas
                this.data = context.getImageData(0, 0, this.width, this.height).data;

                // keep the map repainting
                map.triggerRepaint();

                // return `true` to let the map know that the image was updated
                return true;
            }
        };

        map.on('load', function () {
            map.addImage('pulsing-dot', pulsingDot, {
                pixelRatio: 2
            });

            map.addLayer({
                "id": "places",
                "type": "symbol",
                "source": {
                    "type": "geojson",
                    "data": {
                        "type": "FeatureCollection",
                        "features": features
                    }
                },
                "layout": {
                    "icon-image": "pulsing-dot",
                    "icon-allow-overlap": true
                }
            });
        });
    }

    let getItems = async () => {
        const itemsRaw = await fetch("https://localhost:44390/api/beaches", {
            cache: "no-cache",
            method: "GET"
        });
        const items = await itemsRaw.json();

        console.log(items);

        return items;
    };

    mapboxgl.accessToken = 'pk.eyJ1IjoibXlsaW5kZW4iLCJhIjoiY2p2emk1MXZoMDBreTN6bWZ4NTlxMmsxciJ9.jda2L9BLiahcaIA0vrbtpQ';

    const map = new mapboxgl.Map({
        container: 'myMap',
        style: 'mapbox://styles/mapbox/streets-v11',
        // Ottawa
        center: [-75.4, 45.3],
        zoom: 7.0
    });

    
    function forwardGeocoder(query) {
        var matchingFeatures = [];
        for (var i = 0; i < features.length; i++) {
            var feature = features[i];
            // handle queries with different capitalization than the source data by calling toLowerCase()
            if (feature.properties.name.toLowerCase().search(query.toLowerCase()) !== -1) {
                // add a tree emoji as a prefix for custom data results
                // using carmen geojson format: https://github.com/mapbox/carmen/blob/master/carmen-geojson.md
                feature['place_name'] = '⛱️ ' + feature.properties.name;
                feature['center'] = feature.geometry.coordinates;
                feature['place_type'] = ['beach'];
                matchingFeatures.push(feature);
            }
        }
        return matchingFeatures;
    }

    map.addControl(new MapboxGeocoder({
        accessToken: mapboxgl.accessToken,
        localGeocoder: forwardGeocoder,
        zoom: 14,
        placeholder: "Enter search",
        mapboxgl: mapboxgl
    }));

    getItems().then(res => {
        console.log(res);
        setSel(res);
        setMap(res);
    });

    map.on('click', 'places', function (e) {
        map.flyTo({
            center: e.features[0].geometry.coordinates
        });
    });

    // var popup = new mapboxgl.Popup({
    //     closeButton: false,
    //     closeOnClick: false
    // });

    // map.on('mouseenter', 'places', function (e) {
    map.on('click', 'places', function (e) {
        map.getCanvas().style.cursor = 'pointer';

        var el = e.features[0];

        var coordinates = el.geometry.coordinates.slice();
        var description = "<b>" + el.properties.name + "</b><p>" + el.properties.address + ", " + el.properties.postalCode + '</p><img class="minimized" src="' + el.properties.photo + '">';


        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }
        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML(description)
            .addTo(map);
        // popup.setLngLat(coordinates)
        //     .setHTML(description)
        //     .addTo(map);

    });

    // map.on('mouseleave', 'places', function () {
    //     map.getCanvas().style.cursor = '';
    //     popup.remove();
    // });

    const elBtnGetLength = document.getElementById("btnGetLength");

    elBtnGetLength.addEventListener("click", async () => {
        const text1 = document.getElementById("selFirstPlace");
        const text2 = document.getElementById("selSecondPlace");

        let data = {
            first: text1.value,
            second: text2.value
        };
        console.log(data);

        (async () => {
            const rawResponse = await fetch('https://localhost:44390/api/distance', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });
            var content = await rawResponse.json();

            console.log(content);
            content = content * 100;
            console.log(content);
            var element = document.getElementById("length");
            element.innerText = "Distance: " + content.toFixed(2) + "km";

        })();
    });




});

// $(document).ready($(function () {
//     $('.minimized').click(function (event) {
//         var i_path = $(this).attr('src');
//         $('body').append('<div id="overlay"></div><div id="magnify"><img src="' + i_path + '"><div id="close-popup"><i></i></div></div>');
//         $('#magnify').css({
//             left: ($(document).width() - $('#magnify').outerWidth()) / 2,
//             // top: ($(document).height() - $('#magnify').outerHeight())/2 upd: 24.10.2016
//             top: ($(window).height() - $('#magnify').outerHeight()) / 2
//         });
//         $('#overlay, #magnify').fadeIn('fast');
//     });

//     $('body').on('click', '#close-popup, #overlay', function (event) {
//         event.preventDefault();

//         $('#overlay, #magnify').fadeOut('fast', function () {
//             $('#close-popup, #magnify, #overlay').remove();
//         });
//     });
// }));