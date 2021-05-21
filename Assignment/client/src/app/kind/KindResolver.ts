import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { KindDataService } from "./kind-data.service";
import { Kind } from "./kind.model";

@Injectable({
    providedIn: 'root'
  })
  export class KindResolver implements Resolve<Kind> { 
    constructor(private kindService: KindDataService) {}
   
    resolve(route: ActivatedRouteSnapshot, 
            state: RouterStateSnapshot): Observable<Kind> {
      return this.kindService.getKind$(route.params['kindid']);
    }
  }