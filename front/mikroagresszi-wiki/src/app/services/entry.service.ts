import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Entry} from "../models/entry";

@Injectable({
  providedIn: 'root'
})
export class EntryService {
  private entryUrl:string = 'https://api.mikroagresszi.adena.dev/entry/getBy?categoryId=';
  private entryByUrl:string = 'https://api.mikroagresszi.adena.dev/entry/getById?entryId=';
  private searchByUrl:string = 'https://api.mikroagresszi.adena.dev/entry/searchBy?query=';

  /*private entryUrl:string = 'http://localhost:5071/entry/getBy?categoryId=';
  private entryByUrl:string = 'http://localhost:5071/entry/getById?entryId=';
  private searchByUrl:string = 'http://localhost:5071/entry/searchBy?query=';*/

  constructor(private http: HttpClient) { }

  getBy(categoryId: string) {
    return this.http.get<any>(this.entryUrl + categoryId);
  }

  getById(entryId: string) {
    return this.http.get<Entry>(this.entryByUrl + entryId);
  }

  searchBy(query: string) {
    return this.http.get<any>(this.searchByUrl + query);
  }
}
