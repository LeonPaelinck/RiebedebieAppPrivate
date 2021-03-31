import { Component, OnInit } from '@angular/core';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-kind-list',
  templateUrl: './kind-list.component.html',
  styleUrls: ['./kind-list.component.css']
})
export class KindListComponent implements OnInit {

  constructor(private _kindDataService : KindDataService) { }

  ngOnInit(): void {
  }

  get kinderen() {
    return this._kindDataService.kinderen;
  }

  public addKind(kind: Kind) {
    this._kindDataService.addKind(kind);
    console.log(kind.firstName)
  }

}
