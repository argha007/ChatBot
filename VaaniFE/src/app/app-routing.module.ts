
import { NgModule } from '@angular/core'; 
import { Routes, RouterModule } from '@angular/router'; 
//import { RegisterComponent } from './register/register.component'; 


const routes: Routes = [ 
  // { path: '', redirectTo: 'adduser', pathMatch: 'full', },
  // { path: 'adduser', component: RegisterComponent, data: { title: 'Add User Page' } }, 
]; 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
