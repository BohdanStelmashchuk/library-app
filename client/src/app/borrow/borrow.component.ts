import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {LoansService} from "../services/loans.service";
import {LoanModel} from "../models/loan.model";
import {ActivatedRoute} from "@angular/router";
import {Subject, Subscription, takeUntil} from "rxjs";

@Component({
  selector: 'app-borrow',
  templateUrl: './borrow.component.html',
  styleUrl: './borrow.component.scss'
})
export class BorrowComponent implements OnInit, OnDestroy {
  loanForm!: FormGroup;
  routeSub!: Subscription;
  bookId!: number;
  private destroy$ = new Subject<void>();

  constructor(private fb: FormBuilder,
              private loanService: LoansService,
              private router: ActivatedRoute) {}

  ngOnInit(): void {
    this.routeSub = this.router.params.pipe(
      takeUntil(this.destroy$)).subscribe({
      next: params => {
        this.bookId = +params['bookId']
      },
    });

    this.loanForm = this.fb.group({
      bookId: [this.bookId],
      borrowerId: ['', Validators.required],
      loanDate: [new Date(), Validators.required],
      returnDate: [null]
    });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  onSubmit(): void {
    if (this.loanForm.valid) {
      const loanModel: LoanModel = this.loanForm.value;
      this.loanService.createLoan(loanModel).subscribe({
        next: value => console.log('Loan created successfully', value),
        error: value => console.log('Error creating loan', value),
      });
    }
  }
}
