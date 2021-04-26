import { Component, OnInit } from '@angular/core';
import { Company } from '../shared/interfaces/companies/company';
import { CompanyService } from '../shared/services/companies/company.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent {

  public companies: Company[];

  constructor(companyService: CompanyService) {
    companyService.getList().subscribe((result: Company[]) => {
      this.companies = result;
    }, error => console.error(error));
  }
}
