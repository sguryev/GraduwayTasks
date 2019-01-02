import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkItemModalContentComponent } from './work-item-modal-content.component';

describe('WorkItemModalContentComponent', () => {
  let component: WorkItemModalContentComponent;
  let fixture: ComponentFixture<WorkItemModalContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkItemModalContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkItemModalContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
