import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({ providedIn: 'root' } as any)
export class WorkItemService {

  baseUrl: string;

  constructor(private readonly httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getByEmployeeId(employeeId): Promise<IWorkItemModel[]> {

    return new Promise((resolve, reject) => {
      this.httpClient.get<IWorkItemModel[]>(`${this.baseUrl}api/workitem/employee/${employeeId}`)
        .subscribe(
          result => {
            resolve(result);
            return;
          },
          error => {
            console.error(error);
            reject();
            return;
          });
    });
  }

  getStateDisplay(state: State) {
    switch (state) {
    case State.New:
      return 'new';
    case State.Active:
      return 'active';
    case State.Resolved:
      return 'resolved';
    case State.Closed:
      return 'closed';
    default:
      return null;
    }
  }

  getPriorityDisplay(priority: Priority) {
    switch (priority) {
    case Priority.Low:
      return 'low';
    case Priority.Medium:
      return 'medium';
    case Priority.Critical:
      return 'critical';
    default:
      return null;
    }
  }
}

export enum Priority {
  Critical = 1,
  Medium = 2,
  Low = 3
}

export enum State {
  New = 1,
  Active = 2,
  Resolved = 3,
  Closed = 4
}

export interface IWorkItemModel {
  id: string;
  createdAt: Date;
  title: string;
  description: string;
  priority: Priority;
  state: State;
  employeeId: string;
}
