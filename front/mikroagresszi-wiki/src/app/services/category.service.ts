import { Injectable } from '@angular/core';
import {Category} from "../models/category";
import {HttpClient} from "@angular/common/http";
import * as myGlobals from '../globals';
declare let process: any;

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly baseUrl:string = '';
  private categoriesUrl:string = '/category/getAll';

  constructor(private http: HttpClient) {
    const env = process.env.NODE_ENV;

    if (env  === 'production') {
      this.baseUrl = myGlobals.URL_LIVE;
    } else {
      this.baseUrl = myGlobals.URL_DEV;
    }
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + this.categoriesUrl);
  }
}
