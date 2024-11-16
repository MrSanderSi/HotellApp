import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './RegisterComponent/app.registercomponent'
import { ManageComponent } from './ManageComponent/app.managecomponent'

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'manage', component: ManageComponent },
  { path: '', redirectTo: '/register', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
