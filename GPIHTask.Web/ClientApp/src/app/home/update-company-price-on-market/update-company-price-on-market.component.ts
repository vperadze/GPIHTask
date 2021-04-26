import { Component, OnInit } from '@angular/core';
import { CompanyOnMarketPrice } from '../../shared/interfaces/companyOnMarketPrices/company-on-market-price';
import { Market } from '../../shared/interfaces/markets/market';
import { CompanyOnMarketPriceService } from '../../shared/services/companyOnMarketPrices/company-on-market-price.service';
import { MarketService } from '../../shared/services/markets/market.service';

@Component({
  selector: 'app-update-company-price-on-market',
  templateUrl: './update-company-price-on-market.component.html',
  styleUrls: ['./update-company-price-on-market.component.css']
})
export class UpdateCompanyPriceOnMarketComponent {

  public companyOnMarketPrices: CompanyOnMarketPrice[];
  public markets: Market[];
  constructor(private companyOnMarketPriceService: CompanyOnMarketPriceService, private marketService: MarketService) { this.refreshList(); }

  public refreshList() {
    this.marketService.getList().subscribe((result: Market[]) => {
      this.markets = result;
    }, error => console.error(error));

    this.companyOnMarketPriceService.getList().subscribe((result: CompanyOnMarketPrice[]) => {
      this.companyOnMarketPrices = result;
    }, error => console.error(error));
  }


  public updatePrice(companyOnMarketPrice: CompanyOnMarketPrice) {
    this.companyOnMarketPriceService.companyOnMarketPrice = companyOnMarketPrice;
    this.companyOnMarketPriceService.update().subscribe((result: any) => {

    });
  }
}
