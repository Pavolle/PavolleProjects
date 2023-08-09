/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AuthListComponent } from './auth-list.component';

describe('AuthListComponent', () => {
  let component: AuthListComponent;
  let fixture: ComponentFixture<AuthListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
