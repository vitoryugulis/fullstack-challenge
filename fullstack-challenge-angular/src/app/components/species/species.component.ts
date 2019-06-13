import { Component, OnInit, ViewChild } from '@angular/core';
import { SpeciesService } from 'src/app/core/services/species.service';
import { Species } from 'src/app/core/models/species.model';
import { PaginatedSpecies } from 'src/app/core/models/paginated-species.model';
import { Observable, of, from, defer } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, tap, switchMap, mergeMap } from 'rxjs/operators';
import { SelectorMatcher } from '@angular/compiler';
import { Person } from 'src/app/core/models/person.model';

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
  species : Species;
  totalResults : number = 0;
  people : Person[] = [];
  pageSize = 4;
  page = 1;

  constructor(private speciesService: SpeciesService) { }

  async ngOnInit() {
  }

  selectedItem(species : Species){
    if(species != undefined && species.persons != undefined){
      this.totalResults = species.persons.length;
      this.people = species.persons;
    }
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
            return result.species;
          }),
          catchError(() => {
            this.searchFailed = true;
            return of([]);
          }))
      ),
      tap(() => this.searching = false)
    )

    formatter = (x : Species) => `${x.name} (${x.homeworld})`;

}
