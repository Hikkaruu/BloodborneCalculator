import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimalClassComponent } from './optimal-class.component';

describe('OptimalClassComponent', () => {
  let component: OptimalClassComponent;
  let fixture: ComponentFixture<OptimalClassComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OptimalClassComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimalClassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
