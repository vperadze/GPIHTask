import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterCompanyOnMarketPrice'
})
export class FilterCompanyOnMarketPricePipe implements PipeTransform {

  transform(data: any, arg?: number): any {
    if (!data || !arg) {
      return null;
    }
    var result = data.filter(s => s.marketId === arg);
    return result;
  }
}
