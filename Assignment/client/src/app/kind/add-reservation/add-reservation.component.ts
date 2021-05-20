import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  public kind: Kind;

  constructor(private route: ActivatedRoute,
    private kindDataService: KindDataService) { 
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(pa =>
      this.kindDataService.getKind$(pa.get('kindid'))
        .subscribe(item => this.kind = item)
    );
  }

}
