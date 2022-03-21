import { Component, OnInit } from '@angular/core';
import {EntryService} from "../../services/entry.service";
import {Category} from "../../models/category";

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  private categories: any;

  constructor(private entryService: EntryService) {
  }

  ngOnInit(): void {
    this.categories = [];
    this.entryService.getCategories()
      .subscribe((data: Category) => {this.categories.push(data); console.dir(data);});
  }

}
