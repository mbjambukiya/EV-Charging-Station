import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EvSitesComponent } from './components/ev-sites/ev-sites.component';

const routes: Routes = [
  { path: '', component: EvSitesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
