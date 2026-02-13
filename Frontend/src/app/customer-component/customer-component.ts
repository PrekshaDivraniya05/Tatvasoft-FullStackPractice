import { AfterViewInit, Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Customer, CustomerService } from '../services/customer-service';
import { Subscription, tap } from 'rxjs';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-component',
  imports: [NgFor],
  templateUrl: './customer-component.html',
  styleUrl: './customer-component.css',
})
export class CustomerComponent implements OnInit, AfterViewInit, OnDestroy{

  customers: Customer[] = [];
  private subscription! : Subscription;

  router = inject(Router);

  constructor(private customerService: CustomerService){}
  ngOnInit(): void {
    debugger;
    console.log('ngOnInit called');
    this.customerService.loadCustomers(1, 5);

    this.subscription = this.customerService.customers$
      .subscribe(data => {
        this.customers = data;
      });
  }

  ngAfterViewInit(): void {
    debugger;
    console.log('View Initialized');
  }

  ngOnDestroy(): void {
    console.log('Component Destroyed');
    this.subscription.unsubscribe();
  }

  add(name: string) {
    debugger;
    this.customerService.addCustomer(name)
      .pipe(
        tap(() => this.customerService.loadCustomers(1, 5))
      )
      .subscribe();
  }

  delete(id: number) {
    this.customerService.deleteCustomer(id)
      .pipe(
        tap(() => this.customerService.loadCustomers(1, 5))
      )
      .subscribe();
  }


  update(id:number , name:string){
    this.customerService.updateCustomer(id, name).pipe(
      tap(() => this.customerService.loadCustomers(1, 5))
    )
    .subscribe();
  }

  orders(id: number){
    this.router.navigate([`/orders/${id}`]);
  }
}
