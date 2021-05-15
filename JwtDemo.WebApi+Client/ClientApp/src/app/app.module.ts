import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { SiginInComponent } from './sigin-in/sigin-in.component';
import { SiginUpComponent } from './sigin-up/sigin-up.component';
import { AppRoutingModule } from './app-routing.module';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotifierModule, NotifierOptions } from 'angular-notifier';
import { TokenInterceptor } from './interceptor';
const config:NotifierOptions={
  position:{
    horizontal:{
      position:'right',
    },
    vertical:{
      position:'top'
    }
  }
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminAreaComponent,
    ClientAreaComponent,
    SiginInComponent,
    SiginUpComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    NotifierModule,

  ],
  providers: [
    NgxSpinnerService,
    {provide:HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
