import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Category} from "../models/category";

@Injectable({
  providedIn: 'root'
})
export class EntryService {
  private categoriesUrl:string = 'https://api.mikroagresszi.adena.dev/entry/categories';

  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<Category>(this.categoriesUrl);
  }
}
