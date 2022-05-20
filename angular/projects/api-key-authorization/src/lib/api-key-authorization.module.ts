import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ApiKeyAuthorizationComponent } from './components/api-key-authorization.component';
import { ApiKeyAuthorizationRoutingModule } from './api-key-authorization-routing.module';

@NgModule({
  declarations: [ApiKeyAuthorizationComponent],
  imports: [CoreModule, ThemeSharedModule, ApiKeyAuthorizationRoutingModule],
  exports: [ApiKeyAuthorizationComponent],
})
export class ApiKeyAuthorizationModule {
  static forChild(): ModuleWithProviders<ApiKeyAuthorizationModule> {
    return {
      ngModule: ApiKeyAuthorizationModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ApiKeyAuthorizationModule> {
    return new LazyModuleFactory(ApiKeyAuthorizationModule.forChild());
  }
}
