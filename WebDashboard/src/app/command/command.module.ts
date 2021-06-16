import { NgModule } from '@angular/core';
import { SharedModule } from '../_shared/shared.module';

import { CommandListComponent } from './command-list/command-list.component';



@NgModule({
  declarations: [CommandListComponent],
  imports: [
    SharedModule
  ]
})
export class CommandModule { }
