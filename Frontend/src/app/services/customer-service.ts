import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, tap } from 'rxjs';

export interface Customer{
  customerId: number;
  name: string;
  totalAmount: number
}

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  
  private baseUrl = 'http://localhost:5138/api/Customers';

  constructor(private http: HttpClient){}

  private customerSubject = new BehaviorSubject<Customer[]>([]);
  customers$ = this.customerSubject.asObservable();

  loadCustomers(page:number, size:number){
    debugger;
    this.http.get<Customer[]>(`${this.baseUrl}?PageNumber=${page}&PageSize=${size}`)
    .pipe(
      tap(data => console.log(data)),
      map(data => data.map(c => ({...c, name:c.name.toUpperCase()})))
    )
    .subscribe(data => {
      this.customerSubject.next(data);
    })
  }

  addCustomer(name:string){
    debugger;
    return this.http.post(this.baseUrl, {name})
    .pipe(
      tap(() => console.log("Customer Added")
      )
    );
  }

  deleteCustomer(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  updateCustomer(id:number, name:string){
    return this.http.put(`${this.baseUrl}/${id}`, {name}).pipe(
      tap(() => console.log("updated customer", name)
      )
    );
  }
}
