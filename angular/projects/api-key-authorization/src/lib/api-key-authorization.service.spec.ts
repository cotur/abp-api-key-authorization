import { TestBed } from '@angular/core/testing';

import { ApiKeyAuthorizationService } from './api-key-authorization.service';

describe('ApiKeyAuthorizationService', () => {
  let service: ApiKeyAuthorizationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiKeyAuthorizationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
