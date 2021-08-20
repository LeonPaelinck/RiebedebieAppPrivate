import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';
import { Reservatie } from '../reservatie.model';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {
  
  public kind: Kind;
  private _fetchReservaties$: Observable<Reservatie[]>;

  constructor(private route: ActivatedRoute, private _kindDataService : KindDataService) { 
  }

  ngOnInit(): void {
    this.route.data.subscribe(item => 
      this.kind = item['kind']);

    this._fetchReservaties$ = this._kindDataService.fetchReservaties$(this.kind.id);
  }

  public get reservaties$() {
    return this._fetchReservaties$;
  }

}
