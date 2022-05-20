import { Component, OnInit } from '@angular/core';
import { ApiKeyAuthorizationService } from '../services/api-key-authorization.service';

@Component({
  selector: 'lib-api-key-authorization',
  template: ` <p>api-key-authorization works!</p> `,
  styles: [],
})
export class ApiKeyAuthorizationComponent implements OnInit {
  constructor(private service: ApiKeyAuthorizationService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
