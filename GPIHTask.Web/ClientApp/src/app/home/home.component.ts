import { Component } from '@angular/core';
import { Company } from '../shared/interfaces/companies/company';
import { CompanyOnMarketPrice } from '../shared/interfaces/companyOnMarketPrices/company-on-market-price';
import { Market } from '../shared/interfaces/markets/market';
import { CompanyService } from '../shared/services/companies/company.service';
import { CompanyOnMarketPriceService } from '../shared/services/companyOnMarketPrices/company-on-market-price.service';
import { MarketService } from '../shared/services/markets/market.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public companyOnMarketPrice: CompanyOnMarketPrice[];
  public companies: Company[];
  public markets: Market[];

  constructor(companyOnMarketPriceService: CompanyOnMarketPriceService, companyService: CompanyService, marketService: MarketService) {
    companyService.getList().subscribe((result: Company[]) => {
      this.companies = result;
    }, error => console.error(error));

    marketService.getList().subscribe((result: Market[]) => {
      this.markets = result;
    }, error => console.error(error));

    companyOnMarketPriceService.getList().subscribe((result: CompanyOnMarketPrice[]) => {
      this.companyOnMarketPrice = result;
    }, error => console.error(error));
  }
}
