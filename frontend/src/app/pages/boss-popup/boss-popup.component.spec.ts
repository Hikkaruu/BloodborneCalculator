import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BossPopupComponent } from './boss-popup.component';

describe('BossPopupComponent', () => {
  let component: BossPopupComponent;
  let fixture: ComponentFixture<BossPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BossPopupComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BossPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
