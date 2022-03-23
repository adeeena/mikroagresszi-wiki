import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {CategoryComponent} from "./components/category/category.component";
import {EntryComponent} from "./components/entry/entry.component";
import {MoreInfoComponent} from "./components/more-info/more-info.component";

const routes: Routes = [
  {path: '' , component: HomeComponent},
  {path: 'category' , component: CategoryComponent},
  {path: 'entry' , component: EntryComponent},
  {path: 'more-info' , component: MoreInfoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
