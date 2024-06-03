import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {LoanModel} from "../models/loan.model";

@Injectable({
  providedIn: 'root'
})
export class LoansService {
  private readonly apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.API_URL + '/Loan'
  }

  createLoan(loanModel: LoanModel): Observable<any> {
    return this.http.post(this.apiUrl, loanModel);
  }
}
