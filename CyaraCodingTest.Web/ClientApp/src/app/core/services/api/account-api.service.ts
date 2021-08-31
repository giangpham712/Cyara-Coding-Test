import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationResponse } from '../../dtos/api-dtos';

@Injectable({providedIn: 'root'})
export class AccountApiService {
  constructor(
    private httpClient: HttpClient
  ) { }
  
  login(userName: string, password: string ) {
    return this.httpClient.post<AuthenticationResponse>('account/login', { userName, password });
  }
}