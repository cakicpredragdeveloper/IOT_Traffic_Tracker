import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WelcomeComponent } from './components/welcome/welcome.component';
import { WelcomeCardComponent } from './components/welcome-card/welcome-card.component';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [WelcomeComponent, WelcomeCardComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    RouterModule
  ]
})
export class SharedModule { }
