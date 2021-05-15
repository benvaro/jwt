import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { HomeComponent } from './home/home.component';
import { SiginInComponent } from './sigin-in/sigin-in.component';
import { SiginUpComponent } from './sigin-up/sigin-up.component';

const routes: Routes = [
{path:'',pathMatch:'full',component:HomeComponent},
{path:'sign-up',pathMatch:'full',component:SiginUpComponent},
{path:'sign-in',pathMatch:'full',component:SiginInComponent},
{path:'admin-pannel',pathMatch:'full',component:AdminAreaComponent},
{path:'client-area',pathMatch:'full',component:ClientAreaComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }