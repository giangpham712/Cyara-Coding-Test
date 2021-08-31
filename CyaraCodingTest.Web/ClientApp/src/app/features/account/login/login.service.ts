import { Injectable } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { AccountApiService } from 'src/app/core/services/api/account-api.service';
import { Router } from '@angular/router';

@Injectable()
export class LoginService {
  constructor(
    private router: Router,
    private authService: AuthService,
    private accountApiService: AccountApiService
  ) { }
  
  login(userName: string, password: string) {
    this.accountApiService.login(userName, password).subscribe(
      result => { 
        this.authService.setToken(result.accessToken);
        this.router.navigate(['admin']);
      }
    )
  }
}