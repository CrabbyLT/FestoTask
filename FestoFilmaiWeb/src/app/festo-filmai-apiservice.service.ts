import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FestoFilmaiAPIServiceService {
  readonly baseUrl = 'http://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getMovies(title: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}movies?title=${title}`);
  }
}
