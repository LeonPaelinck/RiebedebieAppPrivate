import { Injectable } from '@angular/core';
import { Kind } from './kind.model';
import { KINDEREN } from './mock-kind';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, delay, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class KindDataService {

  private _kinderen$ = new BehaviorSubject<Kind[]>([]);
  private _kinderen: Kind[];

  constructor(private http: HttpClient) {
    this.kinderen$.subscribe((recipes: Kind[]) => {
      this._kinderen = recipes; //alle kinderen lokaal opslaan
      this._kinderen$.next(this._kinderen); //zodat component automatisch update
    });
   }

  get allKinderen$(): Observable<Kind[]> {
    return this._kinderen$;
  }

  get kinderen$(): Observable<Kind[]> {
    return this.http.get(`${environment.apiUrl}/children/`).pipe(
      catchError(this.handleError),
      tap(console.log),
      map((list: any[]): Kind[] => list.map(Kind.fromJSON))
    );
  }

  getKind$(id: string): Observable<Kind> {
    return this.http
      .get(`${environment.apiUrl}/children/${id}`)
      .pipe(catchError(this.handleError), map(Kind.fromJSON)); // returns just one kind, in json formaat
  }

  public addKind(kind: Kind) {
    //console.log(this._kinderen$);
    return this.http
      .post(`${environment.apiUrl}/children/`, kind.toJSON())
      .pipe(
        catchError(this.handleError), 
        map(Kind.fromJSON))
      .subscribe((arg: Kind) => {
        this._kinderen = [...this._kinderen, arg]; //kind lokaal toevoegen (zodat niet gerefresht moet wordne)
        this._kinderen$.next(this._kinderen);
      });
  }

  deleteKind(kind: Kind) {
    return this.http
    .delete(`${environment.apiUrl}/children/${kind.id}`)
    .pipe(tap(console.log), catchError(this.handleError))
    .subscribe(() => {
      this._kinderen = this._kinderen.filter(k => k.id != kind.id);
      this._kinderen$.next(this._kinderen);
    });
  }

  handleError(err: any): Observable<never>{
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else if (err instanceof HttpErrorResponse) {
      errorMessage = `'${err.status} ${err.statusText}' when accessing '${err.url}'`;
    } else {
      errorMessage = `an unknown error occurred ${err}`;
    }
    //console.error(err);
    return throwError(errorMessage);
  }

 
}
