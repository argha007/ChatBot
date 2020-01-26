import { Component, OnInit,Inject ,EventEmitter, Output,ViewChild  } from '@angular/core';
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import { AppService } from 'src/app/services/app.service'; 
import { ForgotPassword } from 'src/app/models/forgot-password';
import { UserLogin } from 'src/app/models/user-login';
import { AppComponent } from 'src/app/app.component';
import { CaptchaComponent } from 'angular-captcha';

@Component({
  //moduleId: module.id,
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss'],
  providers: [AppService]
})
export class UserLoginComponent implements OnInit {
  public isLoginForm:boolean = true;
  data = false;    
  ForgotPasswordForm: any;
  LoginForm: any;    
  message:string; 
  submitted = false;
  submittedLog = false;
  //@Output() valueChanged: EventEmitter<string> = new EventEmitter();
  constructor(@Inject(AppComponent) 
  private parent: AppComponent,
  private formbulider: FormBuilder,
  private appService:AppService) { }
  @ViewChild(CaptchaComponent, { static: true }) captchaComponent: CaptchaComponent;
  ngOnInit() {
    // this.ForgotPasswordForm = this.formbulider.group({    
    //   ForgotEmail: ['', [Validators.required,Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)]] 
    // });
    this.LoginForm = this.formbulider.group({    
      Email: ['', [Validators.required,Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)]] ,
      Password: ['', [Validators.required]], 
      //userCaptchaInput: ['']  
    });  
    this.captchaComponent.captchaEndpoint = "http://localhost:29210/simple-captcha-endpoint.ashx";
  }
  get f() {this.captchaComponent.captchaEndpoint = "http://localhost:29210/simple-captcha-endpoint.ashx"; return this.ForgotPasswordForm.controls; }
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
        if(data.message==="Password Has Been Sent to your registered email id")
        {
        //this.LoginForm.reset();
        //this.valueChanged.emit("loggedIn");
        alert ("Mail has been sent to your registerd email");
        }
        else
        {
          alert(data.message);
        }
      }
      else{
        alert("We are having issues currently, please try again later");
      }
      
  });   
  }

  onLoginFormSubmit()    
  {    
   
    this.submittedLog = true;
// get the user-entered captcha code value to be validated at the backend side        
let userEnteredCaptchaCode = this.captchaComponent.userEnteredCaptchaCode;

// get the id of a captcha instance that the user tried to solve
let captchaId = this.captchaComponent.captchaId;

const postData = {
  userEnteredCaptchaCode: userEnteredCaptchaCode,
  captchaId: captchaId
};

// post the captcha data to the backend
this.appService.send(postData)
  .subscribe(
    response => {
      if (response.success == false) {
        // captcha validation failed; reload image
        this.captchaComponent.reloadImage();
        // TODO: maybe display an error message, too
      } else {
        // TODO: captcha validation succeeded; proceed with the workflow
      }
    });
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
        if(data.message==="Record is available with us!!!")
        {
        this.LoginForm.reset();
        this.valueChanged.emit("loggedIn");
        }
        else
        {
          alert(data.message);
        }
        
      }
      else{
        alert("We are having issues currently, please try again later");
      }
      
  });   
  }
  toggle() {
    this.isLoginForm = !this.isLoginForm;
  }
  
}
