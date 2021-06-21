import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { ToastrModule } from 'ngx-toastr';
import { SignalRService } from './_shared/services/signal-r.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './_shared/shared.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-top-right',
    }),
    SharedModule
  ],
  providers: [
    SignalRService,
    {
      provide: APP_INITIALIZER,
      useFactory: (signalrService: SignalRService) => () => signalrService.initiateSignalrConnection(),
      deps: [SignalRService],
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
