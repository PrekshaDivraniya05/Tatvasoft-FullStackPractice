import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order, OrderService } from '../services/order-service';
import { FormsModule, NgForm } from '@angular/forms';
import { DatePipe, NgFor } from '@angular/common';


@Component({
  selector: 'app-orders',
  imports:[FormsModule,DatePipe,NgFor],
  templateUrl: './order-component.html',
  standalone:true
})
export class OrderComponent implements OnInit {

  orders: Order[] = [];

  customerId!: number;
  amount!: number;
  orderDate!: string;

  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {

    // read id from URL
    this.customerId = Number(this.route.snapshot.paramMap.get('id'));

    this.loadOrders();
  }

  loadOrders(){
    this.orderService.getOrders()
      .subscribe(data => {
        // filter for this customer only
        this.orders = data.filter(o => o.customerId === this.customerId);
      });
  }

  addOrder(){
    const newOrder = {
      amount: this.amount,
      orderDate: this.orderDate,
      customerId: this.customerId
    };

    this.orderService.addOrder(newOrder)
      .subscribe(() => {
        this.amount = 0;
        this.orderDate = '';
        this.loadOrders();
      });
  }

  deleteOrder(id:number){
    this.orderService.deleteOrder(id)
      .subscribe(() => this.loadOrders());
  }
}

