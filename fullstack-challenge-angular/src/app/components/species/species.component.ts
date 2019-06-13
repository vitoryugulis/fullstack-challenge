import { Component, OnInit, ViewChild } from '@angular/core';
import { SpeciesService } from 'src/app/core/services/species.service';
import { Species } from 'src/app/core/models/species.model';
import { PaginatedSpecies } from 'src/app/core/models/paginated-species.model';
import { Observable, of, from, defer } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, tap, switchMap, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-species',
  templateUrl: './species.component.html',
  styleUrls: ['./species.component.scss']
})
export class SpeciesComponent implements OnInit {

  paginatedSpecies: PaginatedSpecies;
  displayedColumns: string[] = ['name', 'homeworld'];
  speciesInputValue: any = "";
  searching = false;
  searchFailed = false;
  model: any;
  species : Species[] = [];

  constructor(private speciesService: SpeciesService) { }

  async ngOnInit() {
  }



  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => this.searching = true),
      switchMap(term =>
        this.speciesService.getSpeciesByName(term).pipe(
          tap(() => this.searchFailed = false),
          map(result => {
            let speciesNamesAndHomeworlds: string[] = [];
            this.species = result.species;
            result.species.forEach(speciesList =>{
              speciesNamesAndHomeworlds.push(`${speciesList.name} (${speciesList.homeworld})`)
            })
            return speciesNamesAndHomeworlds;
          }),
          catchError(() => {
            this.searchFailed = true;
            return of([]);
          }))
      ),
      tap(() => this.searching = false)
    )

}
