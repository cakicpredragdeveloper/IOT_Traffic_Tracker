import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CommandListComponent } from './command-list/command-list.component';



const routes: Routes = [
  {
    path: '',
    component: CommandListComponent
  }
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CommandRoutingModule {
}
