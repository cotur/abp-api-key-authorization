import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ApiKeyAuthorizationComponent } from './api-key-authorization.component';

describe('ApiKeyAuthorizationComponent', () => {
  let component: ApiKeyAuthorizationComponent;
  let fixture: ComponentFixture<ApiKeyAuthorizationComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ApiKeyAuthorizationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiKeyAuthorizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
