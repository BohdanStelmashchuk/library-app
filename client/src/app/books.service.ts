import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../environments/environment";
import {Observable} from "rxjs";
import {BookModel} from "./models/book";

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private readonly apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.API_URL + '/Book'
  }

  public getBooks(): Observable<BookModel[]> {
    return this.http.get<BookModel[]>(this.apiUrl);
  }

  public deleteBook(book: BookModel) {
    return this.http.delete(this.apiUrl + '/' + book.id);
  }
}
