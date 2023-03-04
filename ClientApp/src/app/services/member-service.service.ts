import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MemberPremiumInput } from '../models/member';
import { Premium } from '../models/premium';
@Injectable({
  providedIn: 'root'
})
export class MemberServiceService {
  _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  calculatePremium(member: MemberPremiumInput): Observable<Premium> {
    return this.http.post<Premium>(this._baseUrl + 'api/member/GetPremium', member);
  }
}
