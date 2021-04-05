import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CustomerService } from 'src/shared/customer.service';

import { CustomerComponent } from './customer.component';

describe('CustomerComponent', () => {
  let component: CustomerComponent;
  let fixture: ComponentFixture<CustomerComponent>;

  let customer: CustomerComponent;
  let service: CustomerService;
  let spy: any;

  beforeEach(() => {
    service = new CustomerService();
    component = new CustomerComponent(service);
  });
  afterEach(() => {
    service = null;
    component = null;
  });

  it('check if customer is already logged in', () => {
    spy = spyOn(service, 'isLogin').and.returnValue(false);
    expect(component.isAlreadyLogin()).toBeFalsy();
    expect(service.isLogin).toHaveBeenCalled();
  });

  it('do login', () => {
    spy = spyOn(service, 'doLogin').and.returnValue(true);
    expect(component.doLogin()).toBeTruthy();
    expect(service.doLogin).toHaveBeenCalled();
  });

  it('do logout', () => {
    spy = spyOn(service, 'dologout').and.returnValue(true);
    expect(component.doLogout()).toBeTruthy();
    expect(service.dologout).toHaveBeenCalled();
  });

  it('is logout', () => {
    spy = spyOn(service, 'isLogout').and.returnValue(true);
    expect(component.isAlreadyLogout()).toBeTruthy();
    expect(service.isLogout).toHaveBeenCalled();
  });

  it('can create product', () => {
    spy = spyOn(service, 'canCreateProduct').and.returnValue(true);
    expect(component.createProduct()).toBeTruthy();
    expect(service.canCreateProduct).toHaveBeenCalled();
  });
});
