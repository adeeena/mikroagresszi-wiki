import { Component } from '@angular/core';
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'mikroagresszi-wiki';
  public isOpened: boolean = false;

  constructor(private translate: TranslateService) {
    translate.setDefaultLang('hu');
  }

  toggleSidenav() {
    this.isOpened = !this.isOpened;
  }

  closeSidenav() {
    this.isOpened = false;
  }


}
