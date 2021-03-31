import { TestBed } from '@angular/core/testing';

import { KindDataService } from './kind-data.service';

describe('KindDataService', () => {
  let service: KindDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KindDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
