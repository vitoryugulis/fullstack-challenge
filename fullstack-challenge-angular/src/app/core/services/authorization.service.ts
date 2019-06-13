import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AuthorizationCredentials } from '../models/authorization-credentials.model';
import { Observable } from 'rxjs';
import { AuthorizationServerResponse } from '../models/authorization-server-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private http: HttpClient) { }

  getAccessToken() : Observable<AuthorizationServerResponse>{
    const credentials: AuthorizationCredentials = {
      clientId : environment.client_id,
      clientSecret : environment.client_secret,
      scope: environment.scope
    }
    return this.http.post<AuthorizationServerResponse>(environment.authorization_server_url, credentials);
  }
}
