import { Component, OnInit } from '@angular/core';
import { KINDEREN } from '../mock-kind';

@Component({
  selector: 'app-kind-list',
  templateUrl: './kind-list.component.html',
  styleUrls: ['./kind-list.component.css']
})
export class KindListComponent implements OnInit {
  private _kinderen = KINDEREN;

  constructor() { }

  ngOnInit(): void {
  }

  public get kinderen() {
    return this._kinderen;
  }

}
