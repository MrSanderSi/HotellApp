import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './NavBar/app.navbar';
import { ManageComponent } from './ManageComponent/app.managecomponent';
import { RegisterComponent } from './RegisterComponent/app.registercomponent';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { BookingComponent } from './BookingComponent/app.bookingcomponent';
import { XRoadInterceptor } from './XRoadInterceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ManageComponent,
    RegisterComponent,
    BookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync('noop'),
    { provide: HTTP_INTERCEPTORS, useClass: XRoadInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
