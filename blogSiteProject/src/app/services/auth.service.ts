import { Injectable } from '@angular/core';
import {LoginUser} from "../models/loginUser";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { AlertifyService } from "./alertify.service";
import { RegisterUser } from "../models/registerUser";
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertifyService: AlertifyService
  ) { }
  path="http://localhost:50343/api/";
  
  login(loginUser:LoginUser){
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type","application/json");
    this.httpClient.get(this.path+"user?mail="+loginUser.mail+"&password="+loginUser.password, {headers:headers}).subscribe(data=>{
      if(data["UserRoles"]=="admin"){
        this.router.navigateByUrl("/cityadd")
      }
      else {this.router.navigateByUrl("/city")}
    })
  }

}
