import {Component, OnDestroy, OnInit} from '@angular/core';
import {BookModel} from "../models/book";
import {BehaviorSubject, combineLatest, debounceTime, map, Observable, Subject, switchMap, takeUntil} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {FilterModel} from "../models/FilterModel";
import {BooksService} from "../books.service";

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})
export class BooksComponent implements OnInit, OnDestroy {
  private booksSubject = new Subject<BookModel[]>();
  books$: Observable<BookModel[]> = this.booksSubject.asObservable();
  private titleFilter$ = new BehaviorSubject<string>('');
  private authorsFilter$ = new BehaviorSubject<string[]>([]);
  private filterObservable$ = new Observable ();
  private destroySubject = new Subject();

  constructor(private route: ActivatedRoute,
              private bookService: BooksService) {
  }

  ngOnInit() {
    this.route.data.pipe(
      map(data => data['books']),
      takeUntil(this.destroySubject)
    ).subscribe({
      next: value => this.booksSubject.next(value)
      }
    );

    this.filterObservable$ = combineLatest([
      this.titleFilter$.asObservable(),
      this.authorsFilter$.asObservable()]).pipe(
      debounceTime(800),
      map(([title, authors]) => ({
        title,
        authors
      }) as FilterModel)
    );

    this.filterObservable$.pipe(
      switchMap(filter => this.bookService.getBooks()),
      takeUntil(this.destroySubject)
    ).subscribe({
      next: value => this.booksSubject.next(value)
      }
    )
  }

  ngOnDestroy() {
    this.destroySubject.next('');
  }

  onTitleFilterChange(event: Event) {
    const input = event.target as HTMLInputElement;
    const value = input.value;
    this.titleFilter$.next(value)
  }

  onAuthorsFilterChange(event: Event) {
    const input = event.target as HTMLInputElement;
    const value = input.value;
    this.authorsFilter$.next(value.split(','));
  }
}
    // this.filterObservable$ = combineLatest([
    //   this.titleFilter$.asObservable(),
    //   this.authorsFilter$.asObservable()]).pipe(
    //   debounceTime(800),
    //   map(([title, authors]) => ({
    //     title,
    //     authors
    //   })),
    //   switchMap(filter => this.filterBooks(filter))
    // );
  //}



  // sendFilterToBackend() {
  //   const filterObservable$ = combineLatest([
  //     this.titleFilter$.asObservable(),
  //     this.authorsFilter$.asObservable()]).pipe(
  //       debounceTime(800),
  //       map(([title, authors]) => ({
  //         title,
  //         authors
  //       })),
  //       switchMap(filter => this.filterBooks(filter))
  //     );

  //   this.subscriptions.push(
  //     filterObservable$.subscribe(filteredBooks => {
  //       this.filteredBooks = filteredBooks;
  //     })
  //   );
  // }

  // filterBooks(filter: {title: string, authors: string}) {
  //   return this.booksService.getBooks().pipe(
  //     map(books => {
  //       return books.filter(book => {
  //         const matchesTitle = book.title.toLowerCase().includes(filter.title.toLowerCase());
  //         const matchesAuthors = book.authors?.some(author => author.toLowerCase().includes(filter.authors.toLowerCase()));
  //         return matchesTitle && matchesAuthors;
  //       });
  //     })
  //   );
  // }

