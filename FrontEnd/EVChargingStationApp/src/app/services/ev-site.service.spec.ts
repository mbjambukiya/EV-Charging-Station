import { TestBed } from '@angular/core/testing';

import { EvSiteService } from './ev-site.service';

describe('EvSiteService', () => {
  let service: EvSiteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EvSiteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
