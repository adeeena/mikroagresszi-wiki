import { Component, OnInit } from '@angular/core';
import {Entry} from "../../models/entry";
import {ActivatedRoute} from "@angular/router";
import {EntryService} from "../../services/entry.service";
import {fadeInUpOnEnterAnimation} from "angular-animations";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  animations: [
    fadeInUpOnEnterAnimation({ anchor: 'enter1', duration: 1000, translate: '30px' }),
  ]
})
export class SearchComponent implements OnInit {
  public query: string = '';
  public count: number = 0;
  public entries: Entry[] = [];

  constructor(private route: ActivatedRoute, private entryService: EntryService) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params =>
    {
      this.query = (params as any).params.query;

      if (this.query) {
        this.entryService.searchBy(this.query)
          .subscribe((data: any) => {
            this.count = data.count;
            this.entries = data.entries;
          });
      }
    });
  }
}
