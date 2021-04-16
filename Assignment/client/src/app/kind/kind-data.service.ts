import { Injectable } from '@angular/core';
import { Kind } from './kind.model';
import { KINDEREN } from './mock-kind';

@Injectable({
  providedIn: 'root'
})
export class KindDataService {

  private _kinderen = KINDEREN;

  constructor() { }

  public get kinderen() {
    return this._kinderen;
  }

  public addKind(kind: Kind) {
    this._kinderen = [...this._kinderen, kind];
    console.log(this._kinderen);
  }

  deleteKind(kind: Kind) {
    const index = this._kinderen.indexOf(kind, 0);
    if (index > -1) {
       this._kinderen.splice(index, 1);
    }   console.log(kind);
   console.log(this._kinderen);
  }
}
