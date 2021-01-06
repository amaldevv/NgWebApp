import { Component, OnInit } from '@angular/core';
import {  HttpClientModule } from '@angular/common/http';

import { Schedule } from 'app/shared/model/schedule';

import { SpeakerService } from "app/services/speaker.service";

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

  errorMessage:string;
  schedules: Schedule[];
  constructor(private scheduleService : SpeakerService  ) { }

  ngOnInit(): void {
    this.scheduleService.GetSchedule(1)
    .subscribe(allSchedule=>  this.schedules = allSchedule,
      (err) => {
        this.errorMessage= err;
        console.log("From list component ", err);
      }

    )
  }

}
