import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule, MatButtonModule, MatTableModule } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    MatButtonModule, MatCheckboxModule, MatTableModule
  ],
  exports: [
    MatButtonModule, MatCheckboxModule, MatTableModule
  ]
})
export class AngularMaterialConfigurationModule { }
