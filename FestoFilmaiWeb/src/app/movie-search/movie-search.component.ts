import { Component, OnInit } from '@angular/core';
import { FestoFilmaiAPIServiceService } from '../festo-filmai-apiservice.service';

@Component({
  selector: 'app-movie-search',
  templateUrl: './movie-search.component.html',
  styleUrls: ['./movie-search.component.css']
})
export class MovieSearchComponent implements OnInit {

  constructor(private service: FestoFilmaiAPIServiceService) { }

  movies: any= [];


  ngOnInit(): void {
  }

  searchMovie(movieName: string) {
    this.service.getMovies(movieName).subscribe(data => {
      this.movies = data;
    });
  }

}
