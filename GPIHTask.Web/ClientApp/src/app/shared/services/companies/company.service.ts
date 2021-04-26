import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HttpHeaderHelper } from '../../classes/http-header-helper';
import { Company } from '../../interfaces/companies/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  company?: Company;
  companyList?: Company[];
  constructor(private http: HttpClient, private httpHeaderHelper: HttpHeaderHelper) { }

  getList() {
    return this.http.get(location.origin + '/api/Company/GetList',
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  create() {
    return this.http.post(location.origin + '/api/Company/Create', this.company,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  update() {
    return this.http.put(location.origin + '/api/Company/Update/' + this.company.id, this.company,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  delete(id: number) {
    return this.http.delete(location.origin + '/api/Company/Delete/' + id,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }
}
