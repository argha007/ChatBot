import { Component, OnInit,Inject  } from '@angular/core';
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import { AppService } from 'src/app/services/app.service'; 
import { ForgotPassword } from 'src/app/models/forgot-password';
import { UserLogin } from 'src/app/models/user-login';
import { AppComponent } from 'src/app/app.component';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {
  public isLoginForm:boolean = true;
  data = false;    
  ForgotPasswordForm: any;
  LoginForm: any;    
  message:string; 
  submitted = false;
  submittedLog = false;
  constructor(@Inject(AppComponent) private parent: AppComponent,private formbulider: FormBuilder,private appService:AppService,) { }

  ngOnInit() {
    this.ForgotPasswordForm = this.formbulider.group({    
      ForgotEmail: ['', [Validators.required,Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)]]    
    });
    this.LoginForm = this.formbulider.group({    
      Email: ['', [Validators.required,Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)]] ,
      Password: ['', [Validators.required]],   
    });   
  }
  get f() { return this.ForgotPasswordForm.controls; }
  get g() { return this.LoginForm.controls; }
  onFormSubmit()    
  {    
   
    this.submitted = true;

        // stop here if form is invalid
        if (this.ForgotPasswordForm.invalid) {
            return;
        }
    const forgotPassword = this.ForgotPasswordForm.value;    
    this.ForgotPasswordRes(forgotPassword);    
  } 
  ForgotPasswordRes(forgotPassword:ForgotPassword)    
  {    
  this.appService.ForgotPassword(forgotPassword).subscribe(    
    data => {
      if(data.statusCode==200)
      {
        alert(data.message);
        this.LoginForm.reset();
      }
      else{
        alert("We are havinbg issues currently, please try again later");
      }
      
  });   
  }

  onLoginFormSubmit()    
  {    
   
    this.submittedLog = true;

        // stop here if form is invalid
        if (this.LoginForm.invalid) {
            return;
        }
    const loginData = this.LoginForm.value;    
    this.LoginRes(loginData);    
  } 
  LoginRes(userLogin:UserLogin)    
  {    
  this.appService.Login(userLogin).subscribe(    
    data => {
      if(data.statusCode==200)
      {
        alert(data.message);
        this.ForgotPasswordForm.reset();
      }
      else{
        this.parent.loggedIn=true;
        alert("We are havinbg issues currently, please try again later");
      }
      
  });   
  }
  toggle() {
    this.isLoginForm = !this.isLoginForm;
  }
  
}
