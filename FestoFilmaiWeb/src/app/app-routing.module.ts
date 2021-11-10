import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MovieSearchComponent } from './movie-search/movie-search.component';

const routes: Routes = [
  {path: 'movie-search', component: MovieSearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
