import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';

import { EmployeeService, IEmployeeModel, EmployeePostModel } from '../services/employee.service';
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

  newEmployee = new EmployeePostModel();
  newEmployeeError: string;

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

  createEmployee(form: NgForm) {
    this.employeeService.post(this.newEmployee)
      .then(employee => {
        this.newEmployee = new EmployeePostModel();
        //todo: insert to the right position OR sort array after OR reload array with selection preserving
        this.employees.push(employee);
        this.select(employee.id);
        form.reset();
      })
      .catch((reason: string) => {
        this.newEmployeeError = reason;
      });
  }
}
