import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class AuthService {
  private isAuthenticatedSource = new ReplaySubject<boolean>(1);
  isAuthenticated$ = this.isAuthenticatedSource.asObservable();

  constructor() { 
    const token = localStorage.getItem('token');
    this.isAuthenticatedSource.next(!!token);
  }

  setToken(token: string) {
    localStorage.setItem('token', token);
    this.isAuthenticatedSource.next(true);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    this.isAuthenticatedSource.next(false);
  }
}