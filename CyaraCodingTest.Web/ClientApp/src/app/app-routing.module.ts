import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'admin',
    canLoad: [AuthGuard],
    loadChildren: () => import('./features/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'account',
    loadChildren: () => import('./features/account/account.module').then((m) => m.AccountModule),
  },
  { path: '**', redirectTo: 'admin' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
