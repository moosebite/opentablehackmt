import React, { Component } from 'react';
import { Counter } from './Counter';
import {
    Button, TextField, FormControlLabel, Switch,
    handleChange, Fab, InputLabel, Select, MenuItem, Checkbox
} from '@material-ui/core';
import './Home.css'
import $ from 'jquery'


export class Home extends Component {
    displayName = Home.name

    onSubmit = (e) => {
        console.log($("#Name").val());
        console.log($("#date").val());
        console.log($("#location").val());
        console.log($("#num_assisted").val());
        console.log($("#notes").val());
        console.log($("#ignore").val());
        console.log($(".flex-container p").text())

        var body = {
            "name_input": $("#Name").val(), //Done
            "date_input": $("#date").val(), //Done
            "num_assisted": $(".flex-container p").text(), //Done
            "location": $("#location").val(), //Done
            "reject_assistance": $("#reject_assistance").val(), //Done
            "other": $("#other").val(), //Done
            "emergency": $("#emergency").val(), 
            "launchpad": $("#launchpad").val(), 
            "mission": $("mission").val(),
            "staging": $("#staging").val(),
            "other_comment": $("other_comment").val()
        }



        $.ajax({
            method: "POST",
            url: "http://localhost:57223/api/Interaction",
            data: JSON.stringify(body),
            contentType: "application/json",
            success: function (data) {
                console.log(data);
            }
        })
            .done(function () {
                alert("Data Saved");
            });

      


     }
    
    render() {
        return ( 
            <div id="home">
                <form>
                    <h2 style={{ paddingTop:'15px'}}>Canvassing Form</h2>
                    <TextField
                        id="Name"
                        name='name'
                        label="Name"
                        placeholder="Enter your Name"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="date"
                        label="Date"
                        type="date"
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />
                    <br/>

                    <TextField
                        id="location"
                        label="Location"
                        placeholder="Enter your Location"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <label id="assistedLabel">People assisted</label>
                    </form>
                    <Counter />

                    <form>
                    <TextField
                        id="reject_assistance"
                        label="Was assistance rejected?  If so, why?"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="other"
                        label="Other"
                        placeholder=""
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />
                    <TextField
                        id="emergency"
                        label="Emergency Services"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="launchpad"
                        label="Launch Pad"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="mission"
                        label="Mission"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="staging"
                        label="Staging"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <TextField
                        id="other_comment"
                        label="Comments"
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                    />

                    <Button variant="contained" color="primary" id="submit" onClick={(e) => this.onSubmit(e)}>
                        Submit
                    </Button>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                  </form>
      </div>
    );
  }
}
