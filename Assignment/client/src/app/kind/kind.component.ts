import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-kind',
  templateUrl: './kind.component.html',
  styleUrls: ['./kind.component.css']
})
export class KindComponent implements OnInit {
  @Input() naam : string = '' ;
  
  constructor() {}

  ngOnInit(): void {
  }

}
