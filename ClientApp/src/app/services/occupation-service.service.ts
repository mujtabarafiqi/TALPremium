import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Occupation } from '../models/occupation';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OccupationServiceService {
  _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getAllOccupations(): Observable<Occupation[]> {
    return this.http.get<Occupation[]>(this._baseUrl + 'api/Occupation/GetAllOccupations');
  }
}
