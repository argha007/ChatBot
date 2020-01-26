import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs'; 
import { ForgotPassword } from '../models/forgot-password';
import { UserLogin } from '../models/user-login';
import { ServiceResponse } from '../models/service-response';
@Injectable({
  providedIn: 'root'
})
export class AppService {

  Url :string;  
  token : string;  
  header : any; 
  constructor(private http : HttpClient) {
    this.Url = 'http://localhost:29210/api';  
    const headerSettings: {[name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings); 
   }
   ForgotPassword(forgotPassword:ForgotPassword)  
   {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json','Access-Control-Allow-Origin': '*' }) };   
    return this.http.get<ServiceResponse>(this.Url + '/login?registeredEmailId='+forgotPassword.ForgotEmail);
   }
   Login(userLogin:UserLogin)  
   {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json','Access-Control-Allow-Origin': '*' }) };   
    return this.http.post<ServiceResponse>(this.Url + '/login/', userLogin);
   }
   
   send(data: Object): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json','Access-Control-Allow-Origin': '*' }) };

    return this.http.post(
      this.Url + '/captcha/', 
      data, httpOptions);
  }
}
