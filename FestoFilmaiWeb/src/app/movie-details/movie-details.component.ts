import { Component, OnInit } from '@angular/core';
import { FestoFilmaiAPIServiceService } from '../festo-filmai-apiservice.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private service: FestoFilmaiAPIServiceService,  private route: ActivatedRoute) { 
    this.route.params.subscribe(params => this.movieId = params["id"]);
  }

  movieId: string = "";
  movie: any;  

  ngOnInit(): void {
    this.getMovieDetails();
  }

  getMovieDetails(){
    this.service.getMovie(this.movieId).subscribe(data => {
      this.movie = data;
      console.log(data);
    });
  }
}
