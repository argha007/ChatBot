import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideBarComponent } from './sidebar/side-bar/side-bar.component';
import { PageHeaderComponent } from './header/page-header/page-header.component';
import { PageFooterComponent } from './footer/page-footer/page-footer.component';
import { UserLoginComponent } from './login/user-login/user-login.component';
import { AppService } from './services/app.service';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChatComponent } from './chat/chat/chat.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { AllUsersComponent } from './allUsers/all-users/all-users.component'; 
@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    PageHeaderComponent,
    PageFooterComponent,
    UserLoginComponent,
    ChatComponent,
    DashboardComponent,
    AllUsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
