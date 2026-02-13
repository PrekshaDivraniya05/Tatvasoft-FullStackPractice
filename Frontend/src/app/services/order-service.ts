import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Order{
  orderId: number,
  amount : number,
  orderDate : string,
  customerId : number
}

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  
  private baseUrl = 'http://localhost:5138/api/Orders';

  constructor(private http: HttpClient){}

  getOrders(): Observable<Order[]>{
    return this.http.get<Order[]>(this.baseUrl);
  }

  getOrdersById(id: number) : Observable<Order>{
    return this.http.get<Order>(`${this.baseUrl}/${id}`);
  }

  addOrder(order : Partial<Order>): Observable<any>{
    return this.http.post(this.baseUrl, order);
  }

  updateOrder(id: number, order : Partial<Order>): Observable<any>{
    return this.http.put(`${this.baseUrl}/${id}`, order);
  }

  deleteOrder(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
