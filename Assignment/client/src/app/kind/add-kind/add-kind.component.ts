import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-add-kind',
  templateUrl: './add-kind.component.html',
  styleUrls: ['./add-kind.component.css']
})
export class AddKindComponent implements OnInit {

  @Output() public newKind = new EventEmitter<Kind>();

  constructor() { }

  ngOnInit(): void {
  }

  addKind(lastname: HTMLInputElement, firstname: HTMLInputElement, birthdate: HTMLInputElement): boolean {
    console.log(firstname.value + birthdate.value);
    const kind = new Kind(lastname.value, firstname.value, new Date(birthdate.value));
    this.newKind.emit(kind);
    return false;
  }

}
