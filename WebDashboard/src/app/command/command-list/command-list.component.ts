import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {Command} from '../../_shared/models/command';
import {CommandService} from '../command.service';

@Component({
  selector: 'app-command-list',
  templateUrl: './command-list.component.html',
  styleUrls: ['./command-list.component.scss']
})
export class CommandListComponent implements OnInit {

  public commands: Command[];

  constructor(private commandService: CommandService) { }

  ngOnInit(): void {
    this.initializeComponent();
  }

  private initializeComponent(): void {
    this.fetchCommands();
  }

  private fetchCommands(): void {
    this.commandService.getCommands().subscribe(
      result => {
        this.commands = result;
      }
    );
  }
}
