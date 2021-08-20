import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthenticationService } from '../user/authentication.service';
import { KindDataService } from '../kind/kind-data.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  titel = "Riebedebie";
  loggedInUser$ = this._authenticationService.user$;

  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private _authenticationService: AuthenticationService,
    private _router: Router
  ) {}

  logout() {
    this._authenticationService.logout();
    //navigeren naar startpagina?
    window.location.reload();
    ///this._router.navigate(['/login']);
  }
  login() {
    console.log('login');
    this._router.navigate(['/login']);
  }
}
