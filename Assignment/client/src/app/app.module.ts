import { NgModule } from '@angular/core';
//import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { KindModule } from './kind/kind.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material/material.module';



@NgModule({
  imports: [
    BrowserModule,
    KindModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,

    AppRoutingModule
  ],
  providers: [],
  declarations: [AppComponent, PageNotFoundComponent, MainNavComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
