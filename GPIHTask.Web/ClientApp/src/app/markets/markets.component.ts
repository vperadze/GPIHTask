import { Component, OnInit } from '@angular/core';
import { Market } from '../shared/interfaces/markets/market';
import { MarketService } from '../shared/services/markets/market.service';

@Component({
  selector: 'app-markets',
  templateUrl: './markets.component.html',
  styleUrls: ['./markets.component.css']
})
export class MarketsComponent {

  public markets: Market[];

  constructor(marketService: MarketService) {
    marketService.getList().subscribe((result: Market[]) => {
      this.markets = result;
    }, error => console.error(error));
  }
}
