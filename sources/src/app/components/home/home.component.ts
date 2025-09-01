import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {fadeInUpOnEnterAnimation} from "angular-animations";
import {Router} from "@angular/router";
import {Title} from "@angular/platform-browser";
import {MatInputModule} from '@angular/material/input';
import {SidenavService} from "../../services/sidenav-service.service";
import {SearchService} from "../../services/search.service";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    animations: [
        fadeInUpOnEnterAnimation({ anchor: 'enter1', duration: 1000, delay: 100, translate: '30px' })
    ],
    standalone: false
})
export class HomeComponent implements OnInit {
  private searchText: string = '';
  private _router: Router;
  public searchResults: any = [];

  constructor(_router: Router, private titleService: Title, private sidenav: SidenavService, private searchService: SearchService) {
    this._router = _router;
  }

  ngOnInit(): void {
    this.titleService.setTitle('Mikroagresszió Wiki');
  }

  searchUpdated($event: Event) {
    if (($event as any).target) {
      this.searchText = ($event as any).target.value;

      if (this.searchText.length < 3) {
        this.searchResults = [];
        return;
      }

      this.searchService.search(this.searchText, 'hu').subscribe(
        (results) => {
          this.searchResults = results;
          console.dir(results);
        },
        (error) => {
          console.error('Error fetching search results:', error);
        }
      );
    }
  }

  sidenavToggle() {
    this.sidenav.toggle();
  }
}
