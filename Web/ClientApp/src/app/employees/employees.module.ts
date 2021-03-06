import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { EmployeesComponent } from './employees.component';
import { WorkItemModalContentComponent } from './work-item-modal-content/work-item-modal-content.component';

const routes: Routes = [
  {
    path: 'employees',
    component: EmployeesComponent,
    children: [
      { path: '', pathMatch: 'full', component: EmployeesComponent }
    ]
  }
];

@
NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgbModule,
    FormsModule
  ],
  declarations: [
    EmployeesComponent,
    WorkItemModalContentComponent
  ],
  entryComponents: [
    WorkItemModalContentComponent
  ]
})
export class EmployeesModule { }
