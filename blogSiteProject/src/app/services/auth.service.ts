import { Injectable } from '@angular/core';
import {LoginUser} from "../models/loginUser";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { AlertifyService } from "./alertify.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }
}
