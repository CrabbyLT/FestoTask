import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailsComponent } from './movie-details/movie-details.component';

import { MovieSearchComponent } from './movie-search/movie-search.component';

const routes: Routes = [
  {path: 'movie-search', component: MovieSearchComponent},
  {path: 'movie-details/:id', component: MovieDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
