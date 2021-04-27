import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Kind } from '../kind.model';

function validateKind(control: FormGroup)
  : { [key: string]: any } {
    /* if (control.get('firstName').value == null || control.get('lastName').value == null)
       {
        return { required: true}
      }
    else */ if (
      new Date(control.get('birthDate').value) >= new Date()
    ) {
      return { dateInFuture: true };
    } else if (
      new Date().getFullYear() - new Date(control.get('birthDate').value).getFullYear() >= 16
    ) {
      return { adult: true };
    }
  return null;
}

@Component({
  selector: 'app-add-kind',
  templateUrl: './add-kind.component.html',
  styleUrls: ['./add-kind.component.css']
})

export class AddKindComponent implements OnInit {
  public kind: FormGroup;

  @Output() public newKind = new EventEmitter<Kind>();

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.kind = this.fb.group({
      firstName: ['Chiara', [Validators.required]],
      lastName: ['Van Campe', [Validators.required]],
      birthDate: ['2010-10-04', [Validators.required]]
    },
    { validator: validateKind }
    );
  }

  onSubmit() {
    const kind = new Kind(this.kind.value.lastName, this.kind.value.firstName, new Date( this.kind.value.birthDate));
    this.newKind.emit(kind);
  }

  getErrorMessage(errors: any): string {
    if (!errors) {
      return null;
    }
    if (errors.required != null && errors.required) {
      return 'is verplicht';
    } else if (errors.dateInFuture) {
      return 'geboortedatum kan niet in toekomst liggen';
    } else if (errors.adult) {
      return 'dit kind is te oud'
    }
  }
}
