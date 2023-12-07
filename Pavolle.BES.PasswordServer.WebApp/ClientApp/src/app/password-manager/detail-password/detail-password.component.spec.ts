import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailPasswordComponent } from './detail-password.component';

describe('DetailPasswordComponent', () => {
  let component: DetailPasswordComponent;
  let fixture: ComponentFixture<DetailPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailPasswordComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
