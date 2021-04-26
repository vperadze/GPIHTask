import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HttpHeaderHelper } from '../../classes/http-header-helper';
import { ApplicationUser } from '../../interfaces/applicationUsers/application-user';

@Injectable({
  providedIn: 'root'
})
export class ApplicationUserService {

  applicationUser?: ApplicationUser;
  applicationUserList?: ApplicationUser[];
  constructor(private http: HttpClient, private httpHeaderHelper: HttpHeaderHelper) { }

  getList() {
    return this.http.get(location.origin + '/api/ApplicationUser/GetList',
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  login(loginForm: any) {
    return this.http.post(location.origin + '/api/ApplicationUser/login', loginForm)
  }

  create() {
    return this.http.post(location.origin + '/api/ApplicationUser/Create', this.applicationUser,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  update() {
    return this.http.put(location.origin + '/api/ApplicationUser/Update/' + this.applicationUser.id, this.applicationUser,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }

  delete(id: number) {
    return this.http.delete(location.origin + '/api/ApplicationUser/Delete/' + id,
      { headers: this.httpHeaderHelper.createDefaultHttpHeader() });
  }
}


