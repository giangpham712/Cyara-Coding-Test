import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { GenerateApiTokenRequest } from 'src/app/core/dtos/api-dtos';
import { TokenApiService } from 'src/app/core/services/api/token-api.service';
import { ApiToken } from 'src/app/shared/models/token.model';

@Injectable()
export class HomeService {
  private tokensSource = new BehaviorSubject<ApiToken[]>([]);
  tokens$ = this.tokensSource.asObservable();

  constructor(
    private tokenApiService: TokenApiService
  ) { }
  
  loadTokens() {
    this.tokenApiService.getTokens(1, 100).subscribe(
      result => this.tokensSource.next(result.items)
    );
  }

  createToken(appUrl: string) {
    const request: GenerateApiTokenRequest = {
      appUrl
    };
    
    this.tokenApiService.generate(request).subscribe(
      result => {
        this.loadTokens();
      }
    );
  }
}