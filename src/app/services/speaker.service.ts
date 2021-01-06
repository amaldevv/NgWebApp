import { Injectable } from '@angular/core';



import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/do';
import { Observable } from "rxjs/Observable";

import { Speaker } from "app/shared/model/speaker";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

import { UtilitiesService } from './utilities.service';

@Injectable({
  providedIn: 'root'
})
export class SpeakerService {
  
  baseUrl = this.utilitiesService.getApiUrl();
  endpoint = this.baseUrl + '/api/GetSpeakers';
  constructor(private httpClient: HttpClient, private utilitiesService: UtilitiesService) { 
    



    
  }

  GetSpeakers(): Observable<any> {

    return this.httpClient.get<Speaker>(this.endpoint)
    //.map(response => response.json())
    //.map(response => response.map(this.formatEmployee))
    .do(response => console.log(response))
    .catch(this.handleError);

  }

  private handleError(error: HttpErrorResponse): any {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }
}
