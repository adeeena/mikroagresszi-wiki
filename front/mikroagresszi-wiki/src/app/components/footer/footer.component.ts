import { Component, OnInit } from '@angular/core';
import { faGithub, faDiscord, faPatreon } from "@fortawesome/free-brands-svg-icons";
import {faEnvelope} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  faGithub = faGithub;
  faDiscord = faDiscord;
  faEnvelope = faEnvelope;
  faPatreon = faPatreon;

  constructor() { }

  ngOnInit(): void {
  }

}
