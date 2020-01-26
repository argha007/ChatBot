import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Vaani Chat Bot';
  public loggedIn:boolean = true;
  showChat: boolean = false;
  showDashBoard: boolean = true;
  showUserData: boolean = false;
  onValueChange(newVal){
    this.showChat = newVal;

    switch(newVal) { 
      case "chat": { 
        this.showChat = true;
        this.showDashBoard = false;
        this.showUserData = false;
         break; 
      } 
      case "home": { 
        this.showChat = false;
        this.showDashBoard = true;
        this.showUserData = false;
         break; 
      }
      case "user": { 
        this.showChat = false;
        this.showDashBoard = false;
        this.showUserData = true;
         break; 
      } 
      default: { 
        this.showChat = false;
        this.showDashBoard = true;
         break; 
      } 
   } 

  }
}
