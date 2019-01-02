import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { EmployeeService, IEmployeeModel } from '../services/employee.service';
import { WorkItemService, IWorkItemModel, Priority, State } from '../services/work-item.service';

import { WorkItemModalContentComponent } from './work-item-modal-content/work-item-modal-content.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent implements OnInit {

  employees: IEmployeeModel[] = [];
  selectedId: string;

  workItems: IWorkItemModel[] = [];

  priority = Priority;
  state = State;

  constructor(
    private readonly employeeService: EmployeeService,
    readonly workItemService: WorkItemService,
    readonly modalService: NgbModal) {

  }

  ngOnInit() {
    this.employeeService.get()
      .then(employees => {
        this.employees = employees;
        if (this.employees.length > 0) {
          this.select(this.employees[0].id);
        }
      });
  }

  select(id) {
    this.selectedId = id;

    this.workItemService.getByEmployeeId(this.selectedId)
      .then(workItems => {
        this.workItems = workItems;
      });
  }

  openWorkItem(workItem: IWorkItemModel) {
    const modalRef = this.modalService.open(WorkItemModalContentComponent, { centered: true });
    modalRef.componentInstance.workItem = workItem;
  }
}
