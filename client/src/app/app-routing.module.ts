import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BooksComponent} from "./books/books.component";
import {BooksResolverService} from "./books-resolver.service";

const routes: Routes = [
  { path: 'books', component: BooksComponent, resolve: {books: BooksResolverService} }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
