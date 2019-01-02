import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({ providedIn: 'root' } as any)
export class EmployeeService {

  baseUrl: string;

  constructor(private readonly httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  get(): Promise<IEmployeeModel[]> {

    return new Promise((resolve, reject) => {
      this.httpClient.get<IEmployeeModel[]>(`${this.baseUrl}api/employee`)
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
}

export interface IEmployeeModel {
  id: string;
  createdAt: Date;
  firstName: string;
  lastName: string;
  position: string;
}
