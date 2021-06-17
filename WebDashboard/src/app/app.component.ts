import {Component, OnInit} from '@angular/core';
import {SignalRService} from './_shared/services/signal-r.service';
import {Command} from './_shared/models/command';
import {ToastrService} from 'ngx-toastr';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'WebDashboard';

  hubHelloMessage: Command;

  constructor(public signalrService: SignalRService,
              public toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.signalrService.hubHelloMessage.subscribe((hubHelloMessage: Command) => {
      this.hubHelloMessage = hubHelloMessage;
      if (this.hubHelloMessage) {
        this.toastrService.success(hubHelloMessage.description, 'Command');
      }
    });

    this.signalrService.connection
      .invoke('Hello')
      .catch(error => {
          console.log(`SignalrDemoHub.Hello() error: ${error}`);
          alert('SignalrDemoHub.Hello() error!, see console for details.');
        }
      );
  }

}
