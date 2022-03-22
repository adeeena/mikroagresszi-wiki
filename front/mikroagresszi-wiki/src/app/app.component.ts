import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'mikroagresszi-wiki';
  public isOpened: boolean = false;

  toggleSidenav() {
    this.isOpened = !this.isOpened;
  }

  closeSidenav() {
    this.isOpened = false;
  }


}
