import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {

  constructor(private window: Window) { }

  getApiUrl() {
      const port = this.getPort();
      return `${this.window.location.protocol}//${this.window.location.hostname}${port}`;
  }

  private getPort() {
      const port = this.window.location.port;
      if (port) {
          // for running with Azure Functions local emulator
          if (port === '4200') {
              // Local run with 'npm run' also started in api folder for Azure Functions
              return ':7071'; // for debugging Azure Functions locally
          }
          // Running with local node (which serves Angular and the API)
          return ':' + this.window.location.port;
      }
      else {
          // for running locally with Docker/Kubernetes
          if (this.window.location.hostname === 'localhost') {
              return ':8080';
          }
      }
      return '';
  }
}