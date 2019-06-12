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

  async getAllSpecies(page : number = 0) : Promise<Species>{
    let httpHeaders = await this.setAuthorizationHeaders();
    let speciesUrl = `${environment.fullstack_challenge_api}species/?page=${page}`;
    return await this.httpClient.get<Species>(speciesUrl, {headers:httpHeaders}).toPromise();
  }

  private async setAuthorizationHeaders() : Promise<HttpHeaders>{
    let credentials = await this.authorizationService.getAccessToken().toPromise();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + credentials.accessToken
    });
    return headers;
  }
}
