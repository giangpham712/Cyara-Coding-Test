import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { HomeComponent } from './home/home.component';
import { TokenListComponent } from './home/token-list/token-list.component';
import { CreateTokenComponent } from './home/create-token/create-token.component';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,

    FormsModule,
    ReactiveFormsModule,
    
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatDialogModule,
    MatSlideToggleModule
  ],
  exports: [],
  declarations: [
    HomeComponent,
    TokenListComponent,
    CreateTokenComponent
  ],
  providers: [],
})
export class AdminModule { }
