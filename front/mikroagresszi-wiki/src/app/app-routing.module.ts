import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {CategoryComponent} from "./components/category/category.component";
import {EntryComponent} from "./components/entry/entry.component";

const routes: Routes = [
  {path: '' , component: HomeComponent},
  {path: 'category' , component: CategoryComponent},
  {path: 'entry' , component: EntryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
