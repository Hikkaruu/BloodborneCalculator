import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirearmsComponent } from './firearms.component';

describe('FirearmsComponent', () => {
  let component: FirearmsComponent;
  let fixture: ComponentFixture<FirearmsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FirearmsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FirearmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
