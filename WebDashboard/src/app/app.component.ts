import {Component, OnInit} from '@angular/core';
import {SignalRService} from './_shared/services/signal-r.service';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'WebDashboard';

  constructor(private signalRService: SignalRService,
              private http: HttpClient) {
  }

  ngOnInit(): void {
    // this.signalRService.startConnection();
    // this.signalRService.addCommandsListener();
    // this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get(  'http://localhost:5001/commands-h')
      .subscribe(res => {
        console.log(res);
      });
  }
}
