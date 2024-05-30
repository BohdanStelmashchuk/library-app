import {Component, OnDestroy, OnInit} from '@angular/core';
import {BookModel} from "../models/bookModel";
import {BehaviorSubject, combineLatest, debounceTime, map, Observable, Subject, switchMap, takeUntil} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {FilterModel} from "../models/filterModel";
import {BooksService} from "../books.service";
import {FilteredBooksModel} from "../models/filteredBooksModel";

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
  private filterObservable$ = new Observable<FilterModel>();
  private destroySubject = new Subject();

  result$!: Observable<FilteredBooksModel[]>;

  constructor(private route: ActivatedRoute,
              private bookService: BooksService) {}

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

    this.result$ = this.filterObservable$.pipe(
      switchMap(filter => this.bookService.getFilteredBooks(filter)),
      takeUntil(this.destroySubject)
    );
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
