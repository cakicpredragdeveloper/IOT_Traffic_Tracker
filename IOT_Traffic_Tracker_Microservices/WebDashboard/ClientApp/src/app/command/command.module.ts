import { NgModule } from '@angular/core';
import { SharedModule } from '../_shared/shared.module';

import { CommandListComponent } from './command-list/command-list.component';
import { CommandRoutingModule } from './command-routing.module';



@NgModule({
  declarations: [CommandListComponent],
  imports: [
    SharedModule,
    CommandRoutingModule
  ]
})
export class CommandModule { }
