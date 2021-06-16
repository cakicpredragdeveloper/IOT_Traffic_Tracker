import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Track } from '../../_shared/models/track';
import { TrackService } from '../track.service';

@Component({
  selector: 'app-track-list',
  templateUrl: './track-list.component.html',
  styleUrls: ['./track-list.component.scss']
})
export class TrackListComponent implements OnInit {

  public tracks: Track[];

  constructor(private trackService: TrackService,
              private router: Router) { }

  ngOnInit(): void {
    this.initializeComponent();
  }

  private initializeComponent(): void {
    this.fetchTracks();
  }

  private fetchTracks(): void {
    this.trackService.getTracks().subscribe(
      result => {
        this.tracks = result;
      }
    );
  }
}
