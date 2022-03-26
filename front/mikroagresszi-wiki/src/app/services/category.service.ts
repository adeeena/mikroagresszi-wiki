import { Injectable } from '@angular/core';
import {Category} from "../models/category";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  //private categoriesUrl:string = 'https://api.mikroagresszi.adena.dev/category/getAll';
  private categoriesUrl:string = 'http://localhost:5071/category/getAll';

  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<Category[]>(this.categoriesUrl);
  }
}
