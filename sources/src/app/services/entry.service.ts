import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {Entry} from "../models/entry";
import * as myGlobals from '../globals';
declare let process: any;

@Injectable({
  providedIn: 'root'
})
export class EntryService {
  private readonly baseUrl:string = '';
  private entryByUrl:string = '/entry?languageCode=hu&id=';
  private relatedByUrl:string = '/related?languageCode=hu&id=';

  constructor(private http: HttpClient) {
    const env = process.env.NODE_ENV;

    if (env === 'production') {
      this.baseUrl = myGlobals.URL_LIVE;
    } else {
      this.baseUrl = myGlobals.URL_DEV;
    }
  }

  getById(entryId: string) {
    return this.http.get(this.baseUrl + this.entryByUrl + entryId, {responseType: 'text'});
  }

  related(entryId: string) {
    return this.http.get(this.baseUrl + this.relatedByUrl + entryId, {responseType: 'text'});
  }
}
