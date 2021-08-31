import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AuthGuard } from './guards/auth.guard';
import { ApiInterceptor } from './interceptors/api.interceptor';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
  ],
  exports: [],
  declarations: [],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true
    }
  ],
})
export class CoreModule { }
