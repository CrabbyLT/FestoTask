import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FestoFilmaiAPIServiceService {
  readonly baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getMovies(title: string, page: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}Movies/${title}/?page=${page}`);
  }

  getMovie(id: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}Movies/Movie/${id}`);
  }
}
