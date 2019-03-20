import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import {City} from '../models/city';
import {Router} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClient:HttpClient, 
    private router:Router,
    private alertifyService:AlertifyService) { }

    path="http://localhost:50343/api/";

    getCities():Observable<City[]>{
      return this.httpClient.get<City[]>(this.path+"city");
    }

    getCityByID(cityID):Observable<City>{
      return this.httpClient.get<City>(this.path+"city/"+cityID);
    }

    add(city) {
      this.httpClient.post(this.path+"city",city).subscribe(data=>{
        this.alertifyService.success("City added!");
      })
    }
    
}
