const addresses = document.querySelectorAll('.sharerValues td:nth-of-type(2n)');
const initialAddress = addresses[0].textContent;

L.accessToken = 'pk.eyJ1IjoidGhlZm9vZHNoYXJlbWFwIiwiYSI6ImNqdG5vemRqcTAwbHUzeXM1b2NodTByMDQifQ.l6qyYH6-ng1viSSGoLR2EQ';

let map = L.mapbox.map('map')
    .addLayer(mapboxgl.mapbox.styleLayer('mapbox://styles/mapbox/streets-v11'));

//let map = new mapboxgl.Map({
//    container: 'map',
//    style: 'mapbox://styles/mapbox/streets-v11',
//    minZoom: 5,
//    center: [-79.6682, 44.4119],
//    zoom: 13
//});

const geocoder = L.geocoder('mapbox.places');

addresses.forEach(address => {
    address.addEventListener('click', (e) => {
        e.preventDefault();
        console.log(e.textContent);
        newAddress(e.textContent);
    });
});

newAddress(initialAddress);

function newAddress(address) {
    geocoder.query(address, showMap);
}

function showMap(err, data) {
    // The geocoder can return an area, like a city, or a
    // point, like an address. Here we handle both cases,
    // by fitting the map bounds to an area or zooming to a point.
    if (data.lbounds) {
        map.fitBounds(data.lbounds);
    } else if (data.latlng) {
        map.setView([data.latlng[0], data.latlng[1]], 13);
    }
}
//map.on("load", function () {
    /* Image: An image is loaded and added to the map ~/Content/Images/favicon-32x32.png. */
    //map.loadImage("https://i.imgur.com/MK4NUzI.png", function (error, image) {
        //if (error) throw error;
        //map.addImage("custom-marker", image);
        /* Style layer: A style layer ties together the source and image and specifies how they are displayed on the map. */
        //map.addLayer({
        //    id: "markers",
        //    type: "symbol",
            /* Source: A data source specifies the geographic coordinate where the image marker gets placed. */
//            source: {
//                type: "geojson",
//                data: {
//                    id: "address1",
//                    type: 'FeatureCollection',
//                    place_type: [
//                        "address"
//                    ],
//                    relevance: 1,
//                    properties: {
//                        "accuracy": "point"
//                    },
//                    text: "Georgian Dr",
//                    place_name: "1 Georgian Dr, Barrie, Ontario L4M 4H8, Canada",
//                    features: [
//                        {
//                            type: 'Feature',
//                            properties: {},
//                            geometry: {
//                                type: "Point"
//                            }
//                        }
//                    ]
//                }
//            },
//            layout: {
//                "icon-image": "custom-marker",
//            }
//        });
//    });
//});