import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatListModule} from '@angular/material/list';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatListModule
  ],
  exports: [
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatListModule
  ]
})
export class MaterialModule { }
