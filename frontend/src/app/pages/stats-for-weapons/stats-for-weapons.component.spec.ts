import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatsForWeaponsComponent } from './stats-for-weapons.component';

describe('StatsForWeaponsComponent', () => {
  let component: StatsForWeaponsComponent;
  let fixture: ComponentFixture<StatsForWeaponsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StatsForWeaponsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StatsForWeaponsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
