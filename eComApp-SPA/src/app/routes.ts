import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'dashboard',
    canActivate : [AuthGuard],
    component: DashboardComponent
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
