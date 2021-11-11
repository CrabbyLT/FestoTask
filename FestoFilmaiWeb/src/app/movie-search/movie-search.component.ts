import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FestoFilmaiAPIServiceService } from '../festo-filmai-apiservice.service';

@Component({
  selector: 'app-movie-search',
  templateUrl: './movie-search.component.html',
  styleUrls: ['./movie-search.component.css']
})
export class MovieSearchComponent implements OnInit {
  movieName: any;
  page: number = 1;

  constructor(private router: Router, private activeRouter: ActivatedRoute, private service: FestoFilmaiAPIServiceService) { 
    this.activeRouter.params.subscribe(params => {
      if (params['movieName'] && params['page'] > 0) {
        this.movieName = params['movieName'];
        this.page = params['page'];

        this.searchMovies();
      }
    });
   }

  movies: any= [];
  
  ngOnInit(): void {
  }

  doSearch(){
    this.router.navigate(['/movie-search', { movieName: this.movieName, page: this.page }]);
  }

  searchMovies() {    
    if(this.isEmptyOrSpaces(this.movieName) || this.page < 1) {
      return
    }
    else {
      this.service.getMovies(this.movieName, this.page).subscribe(data => {
        this.movies = data;
      });
    }   
  }
  isEmptyOrSpaces(str: string){
    return str === null || str.match(/^ *$/) !== null;
  }
}
