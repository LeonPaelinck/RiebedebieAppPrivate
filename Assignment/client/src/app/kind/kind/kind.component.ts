import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-kind',
  templateUrl: './kind.component.html',
  styleUrls: ['./kind.component.css']
})
export class KindComponent implements OnInit {
  @Input() public kind : Kind;
  
  @Output()
  delete = new EventEmitter<Kind>();

  constructor() {}

  ngOnInit(): void {
  }

  handleDelete(): void {
    if(confirm("Bent u zeker dat u "+this.kind.firstName+" "+this.kind.lastName + " wil verwijderen?"))
      this.delete.emit(this.kind);
    //console.log(this.kind.firstName);
  }

}
