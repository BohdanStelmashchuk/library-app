import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { BooksComponent } from './books/books.component';
import {BookPipe} from "./pipes/book.pipe";
import {FormsModule} from "@angular/forms";
import { BorrowersComponent } from './borrowers/borrowers.component';
import { BorrowComponent } from './borrow/borrow.component';

@NgModule({
  declarations: [
    AppComponent,
    BooksComponent,
    BookPipe,
    BorrowersComponent,
    BorrowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
