import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TrackListComponent } from './track-list/track-list.component';
import { TrackDetailComponent } from './track-detail/track-detail.component';



const routes: Routes = [
  {
    path: '',
    component: TrackListComponent
  },
  {
    path: ':trackId',
    component: TrackDetailComponent
  }
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrackRoutingModule {
}
