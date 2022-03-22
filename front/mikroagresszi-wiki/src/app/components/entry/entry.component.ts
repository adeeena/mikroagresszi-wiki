import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {EntryService} from "../../services/entry.service";
import {Entry} from "../../models/entry";

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss']
})
export class EntryComponent implements OnInit {
  public entryId: string = '';
  public entry: any;

  constructor(private route: ActivatedRoute, private entryService: EntryService) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.entryId = (params as any).params.id;

      if (this.entryId) {
        this.entryService.getById(this.entryId)
          .subscribe((data: any) => {
            this.entry = data;
            console.dir(this.entry);
          });
      }
    });
  }
}
