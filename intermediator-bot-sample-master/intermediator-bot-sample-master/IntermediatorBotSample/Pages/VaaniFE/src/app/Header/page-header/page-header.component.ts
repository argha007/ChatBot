import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss']
})
export class PageHeaderComponent implements OnInit {

  userImageUrl: any = "../assets/images/contact.png";
  constructor() { }

  ngOnInit() {
  }

}
