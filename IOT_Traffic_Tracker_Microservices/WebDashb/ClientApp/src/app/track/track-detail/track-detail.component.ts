import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Track } from '../../_shared/models/track';
import { TrackService } from '../track.service';


@Component({
  selector: 'app-track-detail',
  templateUrl: './track-detail.component.html',
  styleUrls: ['./track-detail.component.scss']
})
export class TrackDetailComponent implements OnInit {

  public track: Track;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private trackService: TrackService) { }

  ngOnInit(): void {
    this.initializeComponent();
  }

  private initializeComponent(): void {
    this.route.paramMap.subscribe(params => {
      // @ts-ignore
      const trackId: string = params.get('trackId');
      this.fetchTrack(trackId);
    });
  }

  private fetchTrack(trackId: string): void {
    this.trackService.getTrack(trackId).subscribe(
      result => {
        this.track = result;
      }
    );
  }
}
