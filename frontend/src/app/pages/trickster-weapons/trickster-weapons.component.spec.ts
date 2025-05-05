import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TricksterWeaponsComponent } from './trickster-weapons.component';

describe('TricksterWeaponsComponent', () => {
  let component: TricksterWeaponsComponent;
  let fixture: ComponentFixture<TricksterWeaponsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TricksterWeaponsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TricksterWeaponsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
