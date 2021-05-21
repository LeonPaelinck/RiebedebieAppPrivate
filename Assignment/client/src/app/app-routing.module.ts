import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';

const appRoutes: Routes = [
  {
    path: 'kind',
    loadChildren: () => import('./kind/kind.module').then(mod => mod.KindModule)
  },
  /*{ path: 'register', component: RegisterComponent},
  { path: 'login', component: LoginComponent},*/
  { path: '', redirectTo: 'kind/list', pathMatch: 'full'}, //defaultpagina
  { path: '**', component: PageNotFoundComponent} ,//onbestaande urls 
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes, {preloadingStrategy: PreloadAllModules})
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
