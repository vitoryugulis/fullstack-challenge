import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Species } from '../models/species.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthorizationService } from './authorization.service';
import { AuthorizationServerResponse } from '../models/authorization-server-response.model';

@Injectable({
  providedIn: 'root'
})
export class SpeciesService {

  constructor(private httpClient: HttpClient, private authorizationService: AuthorizationService) { }

  getAllSpecies(page : number) : Observable<Species>{
    let httpHeaders = this.setHeaders();
    return this.httpClient.get<Species>(environment.fullstack_challenge_api, {headers:httpHeaders});
  }

  private setHeaders() : HttpHeaders{
    let authorizationServerResponse : AuthorizationServerResponse; 
    this.authorizationService.getAccessToken().subscribe(response => {
      authorizationServerResponse = response;
    });
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + authorizationServerResponse.accessToken
    });

    return headers;
  }
}
