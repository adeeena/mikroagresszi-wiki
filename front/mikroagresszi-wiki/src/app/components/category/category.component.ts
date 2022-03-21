import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {EntryService} from "../../services/entry.service";
import {Category} from "../../models/category";
import {Entry} from "../../models/entry";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  public categoryId: string = '';
  public entries: Entry[] = [];

  constructor(private route: ActivatedRoute, private entryService: EntryService) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params =>
    {
      this.categoryId = (params as any).params.id;

      if (this.categoryId) {
        this.entryService.getBy(this.categoryId)
          .subscribe((data: any) => {this.entries = data.entries; console.dir(data);});
      }
    });
  }

}
