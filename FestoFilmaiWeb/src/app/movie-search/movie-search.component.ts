import { Component, OnInit } from '@angular/core';
import { FestoFilmaiAPIServiceService } from '../festo-filmai-apiservice.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-search',
  templateUrl: './movie-search.component.html',
  styleUrls: ['./movie-search.component.css']
})
export class MovieSearchComponent implements OnInit {
  movieName: any;

  constructor(private service: FestoFilmaiAPIServiceService) {}

  movies: any= [];
  
  ngOnInit(): void {
  }

  searchMovies() {    
    if(this.isEmptyOrSpaces(this.movieName)){
      return
    }
    else {
      this.service.getMovies(this.movieName).subscribe(data => {
        this.movies = data;
      });
    }

    console.log(this.movies[0]);
    
  }
  isEmptyOrSpaces(str: string){
    return str === null || str.match(/^ *$/) !== null;
  }
}
