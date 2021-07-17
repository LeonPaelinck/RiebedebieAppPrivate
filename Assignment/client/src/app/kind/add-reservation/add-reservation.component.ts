import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { KindDataService } from '../kind-data.service';
import { Kind } from '../kind.model';
import { Reservatie } from '../reservatie.model';
import { EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  public kind: Kind;
  public reservatie: FormGroup;
  public errorMessage: string = '';
  public confirmationMessage: string = '';


  constructor(private route: ActivatedRoute,
    private kindDataService: KindDataService,
    private fb: FormBuilder) { 
  }

  onSubmit() {
    const reservatie = new Reservatie(new Date( this.reservatie.value.date), this.reservatie.value.earlier, this.reservatie.value.later, this.kind.id);
    this.kindDataService.addReservatie(reservatie)
    .pipe(
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      })
    )
    .subscribe((res: Reservatie) => {
      this.confirmationMessage = `${this.kind.firstName} is succesvol ingeschreven op ${res.date}`;;
    });
  }

  ngOnInit(): void {
    this.route.data.subscribe(item => 
      this.kind = item['kind']);

    this.reservatie = this.fb.group({
      date: ['2021-08-08', [Validators.required, ]],
      earlier: ['false', [Validators.required]],
      later: ['false', [Validators.required]],    }
    );
  }

}
