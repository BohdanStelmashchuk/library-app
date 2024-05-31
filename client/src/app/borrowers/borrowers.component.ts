import {Component, OnInit} from '@angular/core';
import {BorrowersService} from "../services/borrowers.service";
import {BorrowerModel} from "../models/borrower.model";
import {Observable} from "rxjs";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-borrowers',
  templateUrl: './borrowers.component.html',
  styleUrl: './borrowers.component.scss'
})
export class BorrowersComponent implements OnInit {
  bookId: number = 12;
  result$: Observable<BorrowerModel[]> = new Observable<BorrowerModel[]>();

  constructor(private borrowersService: BorrowersService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.bookId = +params['bookId'];
      this.result$ = this.borrowersService.getBorrowersByBookId(this.bookId);
    });
  }
}
