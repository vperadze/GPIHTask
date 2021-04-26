import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpHeaderHelper } from '../../classes/http-header-helper';
import { Market } from '../../interfaces/markets/market';

@Injectable({
  providedIn: 'root'
})
export class MarketService {

  market?: Market;
  marketList?: Market[];
  constructor(private http: HttpClient, private httpHeaderHelper: HttpHeaderHelper) { }

  getList() {
    return this.http.get(location.origin + '/api/Market/GetList',
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  create() {
    return this.http.post(location.origin + '/api/Market/Create', this.market,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  update() {
    return this.http.put(location.origin + '/api/Market/Update/' + this.market.id, this.market,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  delete(id: number) {
    return this.http.delete(location.origin + '/api/Market/Delete/' + id,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }
}
