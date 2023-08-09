/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AppIssueService } from './app-issue.service';

describe('Service: AppIssue', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppIssueService]
    });
  });

  it('should ...', inject([AppIssueService], (service: AppIssueService) => {
    expect(service).toBeTruthy();
  }));
});
