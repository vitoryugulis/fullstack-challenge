import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Species } from '../models/species.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthorizationService } from './authorization.service';
import { AuthorizationServerResponse } from '../models/authorization-server-response.model';
import { PaginatedSpecies } from '../models/paginated-species.model';
import { switchMap, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SpeciesService {

  constructor(private httpClient: HttpClient, private authorizationService: AuthorizationService) { }

  getSpeciesByName(speciesName: string, page : number = 0) : Observable<PaginatedSpecies>{
    let speciesUrl = `${environment.fullstack_challenge_api}species/?search=${speciesName}&page=${page}`;
    let species = this.authorizationService.getAccessToken().pipe(
      mergeMap(authorizationServiceResponse => {
        const httpHeaders = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + authorizationServiceResponse.accessToken
        });
        return this.httpClient.get<PaginatedSpecies>(speciesUrl, {headers:httpHeaders})
      })
    );
    return species;
  }
}
