import { Component, OnInit } from '@angular/core';
import { CompanyOnMarketPrice } from '../../shared/interfaces/companyOnMarketPrices/company-on-market-price';
import { Market } from '../../shared/interfaces/markets/market';
import { CompanyOnMarketPriceService } from '../../shared/services/companyOnMarketPrices/company-on-market-price.service';
import { MarketService } from '../../shared/services/markets/market.service';

@Component({
  selector: 'app-refresh-company-price-on-market',
  templateUrl: './refresh-company-price-on-market.component.html',
  styleUrls: ['./refresh-company-price-on-market.component.css']
})
export class RefreshCompanyPriceOnMarketComponent implements OnInit {

  public companyOnMarketPrices: CompanyOnMarketPrice[];
  public markets: Market[];
  seconds = 5;
  constructor(private companyOnMarketPriceService: CompanyOnMarketPriceService, private marketService: MarketService) { this.refreshList(); }

  ngOnInit() {
    setInterval(() => { this.refreshList(); }, this.seconds * 1000); 
  }


  public refreshList() {
    this.companyOnMarketPriceService.getList().subscribe((result: CompanyOnMarketPrice[]) => {
      this.companyOnMarketPrices = result;
    }, error => console.error(error));

    this.marketService.getList().subscribe((result: Market[]) => {
      this.markets = result;
    }, error => console.error(error));
  }
}
