import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';
import { Reservatie } from '../reservatie.model';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  public kind: Kind;
  public reservatie: FormGroup;


  constructor(private route: ActivatedRoute,
    private kindDataService: KindDataService,
    private fb: FormBuilder) { 
  }

  onSubmit() {
    const reservatie = new Reservatie(new Date( this.reservatie.value.date), this.reservatie.value.earlier, this.reservatie.value.later);
    this.kindDataService.addReservatie(this.kind, reservatie);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(pa =>
      this.kindDataService.getKind$(pa.get('kindid'))
        .subscribe(item => this.kind = item)
    );

    this.reservatie = this.fb.group({
      date: ['2021-08-08', [Validators.required]],
      earlier: ['false', [Validators.required]],
      later: ['false', [Validators.required]],    }
    );
  }

}
