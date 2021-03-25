import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from 'src/app/shared/Models/company.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  company: Company = new Company();
  constructor(private router: Router) {
    console.log(this.router.getCurrentNavigation().extras.state.comp);
    this.company = this.router.getCurrentNavigation().extras.state.comp;
  }

  ngOnInit(): void {
    this.loadScript('../assets/js/datatables-demo.js');
    this.loadScript('../assets/js/scripts.js');
  }
  private loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }
}
