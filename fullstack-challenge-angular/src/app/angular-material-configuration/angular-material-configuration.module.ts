import { NgModule } from '@angular/core';
import { MatCheckboxModule, MatButtonModule, MatTableModule, MatFormFieldModule, MatInputModule } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    MatButtonModule, MatCheckboxModule, MatTableModule, MatFormFieldModule, MatInputModule
  ],
  exports: [
    MatButtonModule, MatCheckboxModule, MatTableModule, MatFormFieldModule, MatInputModule
  ]
})
export class AngularMaterialConfigurationModule { }
