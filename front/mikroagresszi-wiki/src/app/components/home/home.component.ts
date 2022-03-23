import { Component } from '@angular/core';
import {fadeInUpOnEnterAnimation} from "angular-animations";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    fadeInUpOnEnterAnimation({ anchor: 'enter1', duration: 1000, delay: 100, translate: '30px' }),
    fadeInUpOnEnterAnimation({ anchor: 'enter2', duration: 1000, delay: 300, translate: '30px' }),
    fadeInUpOnEnterAnimation({ anchor: 'enter3', duration: 1000, delay: 500, translate: '30px' }),
    fadeInUpOnEnterAnimation({ anchor: 'enter4', duration: 1000, delay: 700, translate: '30px' }),
  ]
})
export class HomeComponent {

}
