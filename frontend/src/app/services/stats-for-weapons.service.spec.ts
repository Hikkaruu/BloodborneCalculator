import { TestBed } from '@angular/core/testing';

import { StatsForWeaponsService } from './stats-for-weapons.service';

describe('StatsForWeaponsService', () => {
  let service: StatsForWeaponsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatsForWeaponsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
