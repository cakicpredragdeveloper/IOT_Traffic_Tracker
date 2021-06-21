import { Injectable } from '@angular/core';
import { BaseApiService } from '../_shared/services/base-api.service';
import { Observable } from 'rxjs';
import { Track } from '../_shared/models/track';

@Injectable({
  providedIn: 'root'
})
export class TrackService extends BaseApiService {

  public getTracks(): Observable<Track[]> {

    return this.http.get<Track[]>(`${this.apiUrl}/api`);
  }

  public getTrack(trackId: string): Observable<Track> {
    return this.http.get<Track>(`${this.apiUrl}/api/tracks/${trackId}`);
  }
}
