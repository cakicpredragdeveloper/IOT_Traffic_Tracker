import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import {BaseApiService} from './base-api.service';

@Injectable({
  providedIn: 'root'
})
export class SignalRService extends BaseApiService {

  public hubConnection: HubConnection;

  // constructor() {
    // super();
    //
    // this.startConnection();
  // }

  public startConnection = () => {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.apiUrl + '/commands-h')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addCommandsListener = () => {
    this.hubConnection.on('commands', (data) => {
      // Do some work here
      console.log(data);
    });
  }
}
