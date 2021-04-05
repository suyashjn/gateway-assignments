import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CustomerServiceService } from 'src/shared/customer.service';

import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';

@NgModule({
  declarations: [AppComponent, CustomerComponent],
  imports: [BrowserModule],
  providers: [CustomerServiceService],
  bootstrap: [AppComponent],
})
export class AppModule {}
