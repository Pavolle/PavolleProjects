/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AppVersionChangeService } from './app-version-change.service';

describe('Service: AppVersionChange', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppVersionChangeService]
    });
  });

  it('should ...', inject([AppVersionChangeService], (service: AppVersionChangeService) => {
    expect(service).toBeTruthy();
  }));
});
