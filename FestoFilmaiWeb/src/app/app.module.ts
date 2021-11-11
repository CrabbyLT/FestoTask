import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieSearchComponent } from './movie-search/movie-search.component';
import { FestoFilmaiAPIServiceService } from './festo-filmai-apiservice.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { SortableHeader } from './movie-search/sortable.directive';

@NgModule({
  declarations: [
    AppComponent,
    MovieSearchComponent,
    MovieDetailsComponent,
    SortableHeader
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [FestoFilmaiAPIServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
