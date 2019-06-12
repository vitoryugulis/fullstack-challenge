import { Component, OnInit, ViewChild } from '@angular/core';
import { SpeciesService } from 'src/app/core/services/species.service';
import { Species } from 'src/app/core/models/species.model';

@Component({
  selector: 'app-species',
  templateUrl: './species.component.html',
  styleUrls: ['./species.component.scss']
})
export class SpeciesComponent implements OnInit {

  species : Species[] = [];
  
  displayedColumns: string[] = ['name', 'homeworld'];

  constructor(private speciesService: SpeciesService) { }

  async ngOnInit() {
    this.species = await this.speciesService.getAllSpecies();
    console.log(this.species);
  }

}
