import { Component, Directive, EventEmitter, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FestoFilmaiAPIServiceService } from '../festo-filmai-apiservice.service';
import { SortableHeader, SortEvent } from './sortable.directive';

const compare = (v1: string, v2: string) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

@Component({
  selector: 'app-movie-search',
  templateUrl: './movie-search.component.html',
  styleUrls: ['./movie-search.component.css']
})

export class MovieSearchComponent implements OnInit {
  movieName: any;
  page: number = 1;
  movieYear: any;

  @ViewChildren(SortableHeader)
  headers!: QueryList<SortableHeader>;

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
  unfilteredMovies: any = [];

  ngOnInit(): void {
  }

  onSort({column, direction}: SortEvent) {
    // resetting other headers

    console.log(column);
    

   this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
   })

    // sorting movies
    if (direction === '' || column === '') {
      this.movies = this.unfilteredMovies;
    } else {
      this.movies = [...this.movies].sort((a, b) => {
        const res = compare(a[column], b[column]);
        return direction === 'asc' ? res : -res;
      });
    }
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
        this.unfilteredMovies = this.movies;
      });
    }   
  }
  isEmptyOrSpaces(str: string){
    return str === null || str.match(/^ *$/) !== null;
  }

  clearFilters() {
    this.movies = this.unfilteredMovies;
  }

  filterMovies() {
    if (this.movieYear > 0) {
      this.service.getMoviesByYear(this.movieName, this.movieYear, this.page).subscribe(data => {
        this.movies = data;
      });
    }
  }
}
