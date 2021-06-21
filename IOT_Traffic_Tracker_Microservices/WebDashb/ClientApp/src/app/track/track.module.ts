import { NgModule } from '@angular/core';

import { SharedModule } from '../_shared/shared.module';

import { TrackListComponent } from './track-list/track-list.component';
import { TrackDetailComponent } from './track-detail/track-detail.component';

import { TrackRoutingModule } from './track-routing.module';



@NgModule({
  declarations: [TrackListComponent, TrackDetailComponent],
  imports: [
    SharedModule,
    TrackRoutingModule
  ]
})
export class TrackModule { }
