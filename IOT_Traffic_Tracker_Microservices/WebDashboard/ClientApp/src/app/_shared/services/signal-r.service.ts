import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { Command } from '../models/command';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  connection: signalR.HubConnection;
  hubHelloMessage: BehaviorSubject<Command>;

  constructor() {

    this.hubHelloMessage = new BehaviorSubject<Command>(new Command());
  }

  public initiateSignalrConnection(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5001/signalR') // the SignalR server url, in the .NET Project properties
        .build();

      this.setSignalrClientMethods();

      this.connection
        .start()
        .then(() => {
          console.log(`SignalR connection success! connectionId: ${this.connection.connectionId} `);
         resolve();
        })
        .catch((error) => {
          console.log(`SignalR connection error: ${error}`);
          reject();
        });
    });
  }

  private setSignalrClientMethods(): void {
    this.connection.on('commands', (message: Command) => {
      console.log(message);
      this.hubHelloMessage.next(message);
    });
  }
}
