import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CompaniesComponent } from './companies/companies.component';
import { MarketsComponent } from './markets/markets.component';
import { UsersComponent } from './users/users.component';
import { HttpHeaderHelper } from './shared/classes/http-header-helper';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { UpdateCompanyPriceOnMarketComponent } from './home/update-company-price-on-market/update-company-price-on-market.component';
import { RefreshCompanyPriceOnMarketComponent } from './home/refresh-company-price-on-market/refresh-company-price-on-market.component';
import { FilterCompanyOnMarketPricePipe } from './shared/filter-company-on-market-price.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompaniesComponent,
    MarketsComponent,
    UsersComponent,
    LoginComponent,
    UpdateCompanyPriceOnMarketComponent,
    RefreshCompanyPriceOnMarketComponent,
    FilterCompanyOnMarketPricePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', pathMatch: 'full', redirectTo: '/login' },
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'markets', component: MarketsComponent, canActivate: [AuthGuard]  },
      { path: 'companies', component: CompaniesComponent, canActivate: [AuthGuard]  },
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard]  },
    ])
  ],
  exports: [RouterModule],
  providers: [
    HttpHeaderHelper],
  bootstrap: [AppComponent]
})
export class AppModule { }
