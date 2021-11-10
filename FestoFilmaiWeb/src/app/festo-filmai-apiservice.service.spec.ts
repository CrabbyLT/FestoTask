import { TestBed } from '@angular/core/testing';

import { FestoFilmaiAPIServiceService } from './festo-filmai-apiservice.service';

describe('FestoFilmaiAPIServiceService', () => {
  let service: FestoFilmaiAPIServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FestoFilmaiAPIServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
