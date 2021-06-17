import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseApiService } from '../_shared/services/base-api.service';

import { Command } from '../_shared/models/command';

@Injectable({
  providedIn: 'root'
})
export class CommandService extends BaseApiService {

  public getCommands(): Observable<Command[]> {

    return this.http.get<Command[]>(`${this.apiUrl}/api/commands`);
  }

}
