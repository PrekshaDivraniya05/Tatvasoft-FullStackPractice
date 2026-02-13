import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomerComponent } from './customer-component/customer-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CustomerComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('practice-assignment');
}
