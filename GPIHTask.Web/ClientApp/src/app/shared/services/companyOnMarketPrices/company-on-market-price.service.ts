import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpHeaderHelper } from '../../classes/http-header-helper';
import { CompanyOnMarketPrice } from '../../interfaces/companyOnMarketPrices/company-on-market-price';

@Injectable({
  providedIn: 'root'
})
export class CompanyOnMarketPriceService {

  companyOnMarketPrice?: CompanyOnMarketPrice;
  companyOnMarketPriceList?: CompanyOnMarketPrice[];
  constructor(private http: HttpClient, private httpHeaderHelper: HttpHeaderHelper) { }

 getList() {
   return this.http.get(location.origin + '/api/CompanyOnMarket/GetList',
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  update() {
    return this.http.put(location.origin + '/api/CompanyOnMarket/Update/' + this.companyOnMarketPrice.id, this.companyOnMarketPrice,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }
}
