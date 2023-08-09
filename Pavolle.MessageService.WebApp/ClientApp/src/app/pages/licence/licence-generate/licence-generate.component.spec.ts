/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LicenceGenerateComponent } from './licence-generate.component';

describe('LicenceGenerateComponent', () => {
  let component: LicenceGenerateComponent;
  let fixture: ComponentFixture<LicenceGenerateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LicenceGenerateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LicenceGenerateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
