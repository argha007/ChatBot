import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SideBarComponent } from './sidebar/side-bar/side-bar.component';
import { PageHeaderComponent } from './header/page-header/page-header.component';
import { PageFooterComponent } from './footer/page-footer/page-footer.component';

@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    PageHeaderComponent,
    PageFooterComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
