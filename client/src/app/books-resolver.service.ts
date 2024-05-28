import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from "@angular/router";
import { BooksService } from "./books.service";
import { catchError, Observable, of } from "rxjs";
import { BookModel } from "./models/book";

@Injectable({
  providedIn: 'root'
})
export class BooksResolverService {
  constructor(private booksService: BooksService) { }

  resolve: ResolveFn<BookModel> = (route: ActivatedRouteSnapshot,
                                   state: RouterStateSnapshot): Observable<BookModel | any> => {
    console.log('Called Get Product in resolver...', route);
    return this.booksService.getBooks().pipe(
      catchError(error => {
        return of('No data');
      })
    );
  }
}
