import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Category} from "../models/category";
import {Entry} from "../models/entry";

@Injectable({
  providedIn: 'root'
})
export class EntryService {
  private categoriesUrl:string = 'https://api.mikroagresszi.adena.dev/entry/categories';
  private entryUrl:string = 'https://api.mikroagresszi.adena.dev/entry/getBy?categoryId=';
  private entryByUrl:string = 'https://api.mikroagresszi.adena.dev/entry/getById?entryId=';

  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<Category[]>(this.categoriesUrl);
  }

  getBy(categoryId: string) {
    return this.http.get<any>(this.entryUrl + categoryId);
  }

  getById(entryId: string) {
    return this.http.get<Entry>(this.entryByUrl + entryId);
  }
}
