import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Company } from '../shared/Models/company.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private REST_API_SERVER = 'http://localhost:8081';

  constructor(private http: HttpClient) {}

  getAllCompany() {
    return this.http.get<Company[]>(this.REST_API_SERVER + '/companies');
  }

  getCompany(id: number) {
    return this.http.get<Company>(this.REST_API_SERVER + '/companies/' + id);
  }

  addCompany(company: Company) {
    console.log(company);
    return this.http.post<Company>(
      this.REST_API_SERVER + '/companies',
      company
    );
  }

  editCompany(company: Company) {
    console.log(company);
    return this.http.put<Company>(
      this.REST_API_SERVER + '/companies/' + company.id,
      company
    );
  }

  removeCompany(id: number) {
    return this.http.delete(this.REST_API_SERVER + '/companies/' + id);
  }
}
