import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {BorrowerModel} from "../models/borrower.model";

@Injectable({
  providedIn: 'root'
})
export class BorrowersService {
  private readonly apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.API_URL + '/Borrowers'
  }

  public getBorrowersByBookId(bookId: number): Observable<BorrowerModel[]> {
    return this.http.get<BorrowerModel[]>(`${this.apiUrl}/${bookId}`);
  }
}
