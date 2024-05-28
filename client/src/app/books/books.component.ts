import {Component, OnInit} from '@angular/core';
import {BookModel} from "../models/book";
import {BooksService} from "../books.service";

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})
export class BooksComponent implements OnInit {
  filter: string = '';
  books: BookModel[] = [];

  constructor(private booksService: BooksService) {}

  ngOnInit() {
    this.booksService.getBooks().subscribe({
      next: value => this.books = value,
      error: error => console.log(error),
    })
  }
}
