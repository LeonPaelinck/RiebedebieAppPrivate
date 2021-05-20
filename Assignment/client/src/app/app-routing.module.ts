import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const appRoutes: Routes = [
  {
    path: 'kind',
    loadChildren: () => import('./kind/kind.module').then(mod => mod.KindModule)
  },
  { path: '', redirectTo: 'kind/list', pathMatch: 'full'}, //defaultpagina
  { path: '**', component: PageNotFoundComponent} ,//onbestaande urls 
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes, {preloadingStrategy: PreloadAllModules})
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
