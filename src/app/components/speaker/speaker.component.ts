import { Component, OnInit } from '@angular/core';
import {  HttpClientModule } from '@angular/common/http';

import { Speaker } from 'app/shared/model/speaker';

import { SpeakerService } from "app/services/speaker.service";

@Component({
  selector: 'app-speaker',
  templateUrl: './speaker.component.html',
  styleUrls: ['./speaker.component.css']
})
export class SpeakerComponent implements OnInit {

  errorMessage:string;
  speakers: Speaker[];
  constructor(
    private speakerService : SpeakerService    ) {

    }
    
  

  ngOnInit(): void {

    this.speakerService.GetSpeakers()
    .subscribe(allSpeakers =>  this.speakers = allSpeakers,
      (err) => {
        this.errorMessage= err;
        console.log("From list component ", err);
      }

    )

  }

}
