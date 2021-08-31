import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

import { AccountRoutingModule } from './account-rounting.module';

import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    AccountRoutingModule,

    FormsModule,
    ReactiveFormsModule,

    MatIconModule,
    MatButtonModule,
    MatInputModule,
  ],
  exports: [],
  declarations: [
    LoginComponent
  ],
  providers: [],
})
export class AccountModule { }
