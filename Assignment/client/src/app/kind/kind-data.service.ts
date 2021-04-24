import { Injectable } from '@angular/core';
import { Kind } from './kind.model';
import { KINDEREN } from './mock-kind';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class KindDataService {

  private _kinderen = null;

  constructor(private http: HttpClient) { }

  get kinderen$(): Observable<Kind[]> {
    return this.http.get(`${environment.apiUrl}/children`).pipe(
      catchError(this.handleError),
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

  handleError(err: any): Observable<never>{
    let errorMessage: string;
    if (err instanceof HttpErrorResponse) {
      errorMessage = `'${err.status} ${err.statusText}' when accessing '${err.url}'`;
    } else {
      errorMessage = `an unknown error occurred ${err}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

}
