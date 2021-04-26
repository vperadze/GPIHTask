import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApplicationUser } from '../shared/interfaces/applicationUsers/application-user';
import { ApplicationUserService } from '../shared/services/applicationUsers/application-user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {

  public users: ApplicationUser[];

  constructor(applicationUserService: ApplicationUserService) {
    applicationUserService.getList().subscribe((result: ApplicationUser[]) => {
      this.users = result;
    }, error => console.error(error));
  }
}
