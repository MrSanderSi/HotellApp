import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './RegisterComponent/app.registercomponent'
import { ManageComponent } from './ManageComponent/app.managecomponent'
import { BookingComponent } from './BookingComponent/app.bookingcomponent';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'manage', component: ManageComponent },
  { path: '', redirectTo: '/register', pathMatch: 'full' },
  { path: 'registration/:id', component: BookingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
