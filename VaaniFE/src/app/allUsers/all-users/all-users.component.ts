import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  showAllUser: boolean = true;

  editUser(){
    this.showAllUser = false;
  }

  editComplete(){
    this.showAllUser = true;
  }
  profileForm = new FormGroup({

  });
}
