import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { WorkItemService, IWorkItemModel, Priority, State } from '../../services/work-item.service';

@Component({
  selector: 'app-work-item-modal-content',
  templateUrl: './work-item-modal-content.component.html'
})
export class WorkItemModalContentComponent {

  @Input() workItem: IWorkItemModel;

  priority = Priority;
  state = State;

  constructor(
    readonly activeModal: NgbActiveModal,
    readonly workItemService: WorkItemService) {

  }
}
