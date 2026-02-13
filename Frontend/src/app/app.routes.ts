import { Routes } from '@angular/router';
import { CustomerComponent } from './customer-component/customer-component';
import { OrderComponent } from './order-component/order-component';

export const routes: Routes = [
    { path: '', component: CustomerComponent },
    { path: 'orders/:id', component: OrderComponent }
];
