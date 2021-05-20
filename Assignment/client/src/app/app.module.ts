import { NgModule } from '@angular/core';
//import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { KindModule } from './kind/kind.module';
import { ReservationComponent } from './kind/reservation/reservation.component';
import { RouterModule, Routes } from '@angular/router';
import { KindListComponent } from './kind/kind-list/kind-list.component';
import { AddKindComponent } from './kind/add-kind/add-kind.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

const appRoutes: Routes = [
  { path: 'kind/list', component: KindListComponent },
  { path: 'kind/add', component: AddKindComponent },
  { path: '', redirectTo: 'kind/list', pathMatch: 'full'}, //startpagina (enige voorlopig)
  { path: '**', component: PageNotFoundComponent} //onbestaande urls
];

@NgModule({
  imports: [
    BrowserModule,
    KindModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
  providers: [],
  declarations: [AppComponent, ReservationComponent, PageNotFoundComponent, MainNavComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
