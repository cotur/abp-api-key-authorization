import { ModuleWithProviders, NgModule } from '@angular/core';
import { API_KEY_AUTHORIZATION_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ApiKeyAuthorizationConfigModule {
  static forRoot(): ModuleWithProviders<ApiKeyAuthorizationConfigModule> {
    return {
      ngModule: ApiKeyAuthorizationConfigModule,
      providers: [API_KEY_AUTHORIZATION_ROUTE_PROVIDERS],
    };
  }
}
