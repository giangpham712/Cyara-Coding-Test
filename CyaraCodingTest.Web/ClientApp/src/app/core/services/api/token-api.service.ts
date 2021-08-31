import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginatedResult } from 'src/app/shared/models/result.models';
import { ApiToken } from 'src/app/shared/models/token.model';
import { ApiTokenGenerationResponse, GenerateApiTokenRequest } from '../../dtos/api-dtos';

@Injectable({providedIn: 'root'})
export class TokenApiService {
  constructor(
    private httpClient: HttpClient
  ) { }
  
  getTokens(page: number, pageSize: number) {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());
      
    return this.httpClient.get<PaginatedResult<ApiToken>>('token', { params });
  }

  generate(request: GenerateApiTokenRequest) {
    return this.httpClient.post<ApiTokenGenerationResponse>('token/generate', request);
  }
}
