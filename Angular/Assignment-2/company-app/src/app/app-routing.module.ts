import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LayoutComponent } from './layout/layout.component';

const DashboardModule = () =>
  import('./dashboard/dashboard.module').then((x) => x.DashboardModule);
const CompanyModule = () =>
  import('./company/company.module').then((x) => x.CompanyModule);

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: DashboardModule,
      },
      {
        path: 'company',
        loadChildren: CompanyModule,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
