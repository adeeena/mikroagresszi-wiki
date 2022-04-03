import { Component } from '@angular/core';
import {TranslateService} from "@ngx-translate/core";
import {AppConfigService} from "./services/app-config.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public isOpened: boolean = false;

  constructor(private translate: TranslateService,
              private appConfigService: AppConfigService) {
    translate.setDefaultLang(appConfigService.getConfig().languageCode);
  }

  toggleSidenav() {
    this.isOpened = !this.isOpened;
  }

  closeSidenav() {
    this.isOpened = false;
  }


}
