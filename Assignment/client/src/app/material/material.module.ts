import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatListModule} from '@angular/material/list';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatListModule,
    MatInputModule
  ],
  exports: [
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatListModule,
    MatInputModule
  ]
})
export class MaterialModule { }
