import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  logoImgUrl: any = "../assets/images/logo.png";
  @Output() valueChanged: EventEmitter<string> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  valueChange(newVal: string){
    this.valueChanged.emit(newVal);
  }

}
