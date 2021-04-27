import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-kind-list',
  templateUrl: './kind-list.component.html',
  styleUrls: ['./kind-list.component.css']
})
export class KindListComponent implements OnInit {
  private _fetchKinderen$: Observable<Kind[]> 
    = this._kindDataService.allKinderen$;
    public errorMessage: string = '';

  public filterKindName: string;
  public filterKind$ = new Subject<string>();

  constructor(private _kindDataService : KindDataService) {
    this.filterKind$.subscribe(
      val => this.filterKindName = val);
  }     

  ngOnInit(): void {
    this._fetchKinderen$ = this._kindDataService.kinderen$.pipe(
      catchError(err => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
  }

  get kinderen$() : Observable<Kind[]> {
    return this._fetchKinderen$;
  }

  public addKind(kind: Kind) {
    this._kindDataService.addKind(kind);
    //console.log(kind.firstName)
  }

  public deleteKind(kind: Kind): void {
    this._kindDataService.deleteKind(kind);
  }

}
