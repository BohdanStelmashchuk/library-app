import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { BooksComponent } from './books/books.component';
import {BookPipe} from "./book.pipe";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    BooksComponent,
    BookPipe
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
