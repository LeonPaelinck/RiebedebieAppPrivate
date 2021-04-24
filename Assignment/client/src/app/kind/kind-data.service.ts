import { Injectable } from '@angular/core';
import { Kind } from './kind.model';
import { KINDEREN } from './mock-kind';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class KindDataService {

  private _kinderen = null;

  constructor(private http: HttpClient) { }

  get kinderen$(): Observable<Kind[]> {
    return this.http.get('api/children').pipe(
      tap(console.log),
      map((list: any[]): Kind[] => list.map(Kind.fromJSON))
    );
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
