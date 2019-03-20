import { Component, OnInit } from '@angular/core';
import {City} from '../models/city';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {

  constructor(private http:HttpClient) { }
  cities:City[];

  ngOnInit() {
  }

}
