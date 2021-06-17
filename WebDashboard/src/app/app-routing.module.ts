import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WelcomeComponent } from './_shared/components/welcome/welcome.component';

const routes: Routes = [
  {
    path: 'welcome',
    component: WelcomeComponent
  },
  {
    path: 'tracks',
    loadChildren: () => import('./track/track.module').then(m => m.TrackModule)
  },
  {
    path: 'commands',
    loadChildren: () => import('./command/command.module').then(m => m.CommandModule)
  },
  {
    path: '**',
    redirectTo: 'welcome'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
