import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KindListComponent } from './kind-list/kind-list.component';
import { KindComponent } from './kind/kind.component';
import { MaterialModule } from '../material/material.module';
import { AddKindComponent } from './add-kind/add-kind.component';
import { ReactiveFormsModule } from '@angular/forms';
import { KindFilterPipe } from './kind-filter.pipe';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  declarations: [
    KindListComponent, 
    KindComponent, 
    AddKindComponent, KindFilterPipe
  ],
  exports: [
    KindListComponent, 
    AddKindComponent,
    ReactiveFormsModule
  ],
})
export class KindModule { }
