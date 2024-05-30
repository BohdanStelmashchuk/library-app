import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../environments/environment";
import {Observable} from "rxjs";
import {BookModel} from "./models/bookModel";
import {FilterModel} from "./models/filterModel";
import {FilteredBooksModel} from "./models/filteredBooksModel";

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

  public getFilteredBooks(filter: FilterModel): Observable<FilteredBooksModel[]> {
    return this.http.post<FilteredBooksModel[]>(`${this.apiUrl}/filter`, filter);
  }

  public deleteBook(book: BookModel) {
    return this.http.delete(this.apiUrl + '/' + book.id);
  }
}
