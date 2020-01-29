import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Map, GoogleApiWrapper } from 'google-maps-react';
import './Mapping.css';



export class Mapping extends Component {

    constructor(prop) {
        super(prop)
        this.googleMap = null;
        this.googleMapRef = element => {
            this.googleMap = element;
        };

    }
    componentDidMount() {
        this.createGoogleMap()
        this.createMarker()
    }
    createGoogleMap = () =>
        this.gmap = new window.google.maps.Map(this.googleMap, {
            zoom: 16,
            center: {
                lat: 36.1620, lng: -86.7816
            },
            disableDefaultUI: false,
        })

    createMarker = () => {
        var pos = new window.google.maps.LatLng(36.1620, -86.7816);
        
        new window.google.maps.Marker({
            map: this.gmap,
            position: pos
        })
    }

    render() {
        return (
            <div id="container">
            <div
                id="google-map"
                ref={this.googleMapRef}
                style={{ width: '93vw', height: '93vh' }}
                />
            </div>
        )
    }
}


const rootElement = document.getElementById("root");
ReactDOM.render(<Mapping />, rootElement);


