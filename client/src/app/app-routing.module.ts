import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BooksComponent} from "./books/books.component";
import {BooksResolverService} from "./resolvers/books-resolver.service";
import {BorrowersComponent} from "./borrowers/borrowers.component";
import {BorrowComponent} from "./borrow/borrow.component";

const routes: Routes = [
  {
    path: 'books',
    component: BooksComponent,
    resolve: {books: BooksResolverService},
    children: [
      {
        path: ':bookId/borrowers', component: BorrowersComponent
      },
      {
        path: ':id/borrow', component: BorrowComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
