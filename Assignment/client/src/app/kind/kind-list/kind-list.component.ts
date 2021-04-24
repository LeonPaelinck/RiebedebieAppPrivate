import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-kind-list',
  templateUrl: './kind-list.component.html',
  styleUrls: ['./kind-list.component.css']
})
export class KindListComponent implements OnInit {
  private _fetchKinderen$: Observable<Kind[]> 
    = this._kindDataService.kinderen$;

  public filterKindName: string;
  public filterKind$ = new Subject<string>();

  constructor(private _kindDataService : KindDataService) {
    this.filterKind$.subscribe(
      val => this.filterKindName = val);
  }     

  ngOnInit(): void {
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
