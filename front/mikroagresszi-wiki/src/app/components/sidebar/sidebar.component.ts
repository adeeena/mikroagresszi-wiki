import { Component, OnInit } from '@angular/core';
import {EntryService} from "../../services/entry.service";
import {Category} from "../../models/category";
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  @Output() closing = new EventEmitter<string>();
  public categories: Category[] = [];

  constructor(private entryService: EntryService) {
  }

  ngOnInit(): void {
    this.entryService.getCategories()
      .subscribe((data: Category[]) => {this.categories = data; console.dir(data);});
  }

  linkClicked(): void {
    if (this.closing) {
      this.closing.emit('');
    }
  }

}
