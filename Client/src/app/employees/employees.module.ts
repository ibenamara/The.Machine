import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesComponent } from './employees.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { EmployeesService } from './employees.service';

const routes: Routes = [
  {path:'drinks', component: EmployeesComponent}
];

@NgModule({
  imports: [
      CommonModule,
      FormsModule,
      RouterModule.forChild(routes)
  ],
  declarations: [EmployeesComponent]
})
export class EmployeesModule { }
