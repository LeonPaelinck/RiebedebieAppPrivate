import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KindListComponent } from './kind/kind-list/kind-list.component';
import { AddKindComponent } from './kind/add-kind/add-kind.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AddReservationComponent } from './kind/add-reservation/add-reservation.component';

const appRoutes: Routes = [
  { path: 'kind/list', component: KindListComponent },
  { path: 'kind/add', component: AddKindComponent },
  { path: 'kind/add-reservation/:kindid', component: AddReservationComponent },
  { path: '', redirectTo: 'kind/list', pathMatch: 'full'}, //defaultpagina
  { path: '**', component: PageNotFoundComponent} ,//onbestaande urls
  
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
