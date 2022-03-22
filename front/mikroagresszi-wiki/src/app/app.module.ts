import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule} from "@angular/material/toolbar";
import { MatIconModule} from "@angular/material/icon";
import { MatButtonModule} from "@angular/material/button";
import { AppRoutingModule } from './app-routing.module';
import {MatSidenavModule} from "@angular/material/sidenav";
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import {HttpClientModule} from "@angular/common/http";
import { CategoryComponent } from './components/category/category.component';
import {MatCardModule} from "@angular/material/card";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { EntryComponent } from './components/entry/entry.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    SidebarComponent,
    CategoryComponent,
    EntryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    HttpClientModule,
    MatCardModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
