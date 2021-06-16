import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseApiService {
  protected apiUrl: string;

  constructor(protected router: Router,
              protected http: HttpClient) {

    this.apiUrl = environment.API_URL;
  }
}
