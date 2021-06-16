import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WelcomeComponent } from './components/welcome/welcome.component';
import { WelcomeCardComponent } from './components/welcome-card/welcome-card.component';
import { RouterModule } from '@angular/router';



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
