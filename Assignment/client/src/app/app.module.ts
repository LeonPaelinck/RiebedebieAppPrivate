import { NgModule } from '@angular/core';
//import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { KindModule } from './kind/kind.module';
import { ReservationComponent } from './kind/reservation/reservation.component';

@NgModule({
  imports: [
    BrowserModule,
    KindModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  declarations: [AppComponent, ReservationComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
