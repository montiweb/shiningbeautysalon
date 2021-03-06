import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainLayoutComponent } from './layout/layout-main/main-layout/main-layout.component';
import { PanelLayoutComponent } from './layout/layout-panel/panel-layout/panel-layout.component';
import { HomePageComponent } from './modules/home/home-components/home-page.component';
import { LoginFormComponent } from './modules/login/login-components/login-form.component';
import { PanelFormComponent } from './modules/panel/panel-components/panel-form.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'index',
        component: HomePageComponent,
        pathMatch: 'full'
      },
      {
        path: 'home',
        component: HomePageComponent,
        pathMatch: 'full'
      },
      {
        path: '',
        component: HomePageComponent,
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    component: PanelLayoutComponent,
    children: [
      {
        path: 'panel/:panelAuthenticate',
        component: PanelFormComponent,
        pathMatch: 'full'
      }
    ]
  },
  {
    path: 'login',
    component: LoginFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
