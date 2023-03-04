import { TestBed } from '@angular/core/testing';

import { OccupationServiceService } from './occupation-service.service';

describe('OccupationServiceService', () => {
  let service: OccupationServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OccupationServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
