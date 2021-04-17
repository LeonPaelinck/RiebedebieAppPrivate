import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-add-kind',
  templateUrl: './add-kind.component.html',
  styleUrls: ['./add-kind.component.css']
})

export class AddKindComponent implements OnInit {
  public kind: FormGroup;

  @Output() public newKind = new EventEmitter<Kind>();

  constructor() { }

  ngOnInit() {
    this.kind = new FormGroup({
      firstName: new FormControl('JP',
      [Validators.required]),
      lastName: new FormControl('Van Lierde',
      [Validators.required]),
      birthDate: new FormControl('2010-10-04',
      [Validators.required])
    })
  }

  onSubmit() {
    const kind = new Kind(this.kind.value.lastName, this.kind.value.firstName, new Date( this.kind.value.birthDate));
    console.log(this.kind.value.birthDate);
    console.log(new Date( this.kind.value.birthDate));
    this.newKind.emit(kind);
  }

  getErrorMessage(errors: any): string {
    if (errors.required) {
      return 'is verplicht';
    }
  }
}
