import React, { Component } from 'react';
import './Counter.css';
import $ from "jquery";

export class Counter extends Component {
  displayName = Counter.name

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
      this.incrementCounter = this.incrementCounter.bind(this);
      this.decrementCounter = this.decrementCounter.bind(this);
  }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });

        //user id
        var userId = 1;


    
        

    //    var body = {
    //public string Name_input { get; set; }
    //    public DateTime ? Date_input { get; set; }
    //    public int ? Num_assisted { get; set; }
    //    public string Location { get; set; }
    //    public string Reject_assistance { get; set; }
    //    public int ? Other{ get; set; }
    //    public int ? Emergency { get; set; }
    //    public int ? Launchpad { get; set; }
    //    public int ? Mission { get; set; }
    //    public int ? Staging { get; set; }
    //    public string Other_comment { get; set; }
    //    }
        

        var body =
        {
            name_input: null,
            date_input: null,
            num_assisted: null, 
            location: null, 
            reject_assistance: null,
            other: null,
            emergency: null,
            launchpad: null,
            mission: null,
            staging: null,
            other_comment: null
        };

        $.ajax({
            'url': `http://localhost:57223/api/Interaction?id=${1}`,
            'type': 'GET',
            'data': body,
            'success': function (data) {
                console.log(data);
            }
        });

        $.ajax({
            method: "POST",
            url: "http://localhost:57223/api/Interaction",
            data: body,
            contentType: "application/json",
            success: function (data) {
                console.log(data);
            }

        });

        //$.post('http://localhost:57934/api/Interaction?id=${1}', body, function (data) {
            //console.log(data);
        //});

        console.log(JSON.stringify(body));

        //$.ajax({
        //    'type': "POST",
        //    'url': `http://localhost:57934/api/Interaction`,
        //    'data': body,
        //    'success': function (data) {
        //        console.log(data);
        //    },
        //    'dataType': 'json'
        //});


      


    }

    decrementCounter() {
        if (this.state.currentCount !== 0) {
            this.setState({
                currentCount: this.state.currentCount - 1
            });
        }
    }

  render() {
    return (
      <div className="flex-container">

        <button class="counterBtn" onClick={this.decrementCounter}><span id="minus">-</span></button>

        <p><strong>{this.state.currentCount}</strong></p>

        <button class="counterBtn" onClick={this.incrementCounter}><span id="plus">+</span></button>
      </div>
    );
  }
}
