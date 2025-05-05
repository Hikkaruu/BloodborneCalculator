import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BossComponent } from './boss.component';

describe('BossComponent', () => {
  let component: BossComponent;
  let fixture: ComponentFixture<BossComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BossComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BossComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
