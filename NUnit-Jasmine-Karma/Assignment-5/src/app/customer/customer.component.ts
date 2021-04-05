import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/shared/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {}
  doLogin(): boolean {
    console.log(this.customerService.doLogin());
    return this.customerService.doLogin();
  }
  isAlreadyLogin(): boolean {
    return this.customerService.isLogin();
  }
  doLogout(): boolean {
    return this.customerService.dologout();
  }
  isAlreadyLogout(): boolean {
    return this.customerService.isLogout();
  }
  createProduct(): boolean {
    return this.customerService.canCreateProduct();
  }
}
