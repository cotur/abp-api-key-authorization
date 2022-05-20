import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ApiKeyAuthorization',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44315',
    redirectUri: baseUrl,
    clientId: 'ApiKeyAuthorization_App',
    responseType: 'code',
    scope: 'offline_access ApiKeyAuthorization role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44315',
      rootNamespace: 'Cotur.Abp.ApiKeyAuthorization',
    },
    ApiKeyAuthorization: {
      url: 'https://localhost:44362',
      rootNamespace: 'Cotur.Abp.ApiKeyAuthorization',
    },
  },
} as Environment;
