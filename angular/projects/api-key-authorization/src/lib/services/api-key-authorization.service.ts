import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ApiKeyAuthorizationService {
  apiName = 'ApiKeyAuthorization';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/ApiKeyAuthorization/sample' },
      { apiName: this.apiName }
    );
  }
}
