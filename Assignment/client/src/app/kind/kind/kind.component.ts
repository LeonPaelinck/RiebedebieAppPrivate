import { Component, Input, OnInit } from '@angular/core';
import { Kind } from '../kind.model';

@Component({
  selector: 'app-kind',
  templateUrl: './kind.component.html',
  styleUrls: ['./kind.component.css']
})
export class KindComponent implements OnInit {
  @Input() public kind : Kind;
  
  constructor() {}

  ngOnInit(): void {
  }

}
