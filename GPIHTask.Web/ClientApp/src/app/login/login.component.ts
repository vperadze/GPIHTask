import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApplicationUserService } from '../shared/services/applicationUsers/application-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  checkoutForm = new FormGroup({ userName: new FormControl(), password: new FormControl() });

  constructor(private applicationUserService: ApplicationUserService, private router: Router, private formBuilder: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.checkoutForm = this.formBuilder.group({
      userName: "",
      password: ""
    });
  }

  ngOnInit() {
    localStorage.setItem('token', '');
    if (localStorage.getItem('token') != '') { this.router.navigateByUrl('/home'); }
    else {
      this.router.navigateByUrl('/login');
    }
  }

  onSubmit() {
    this.applicationUserService.login(this.checkoutForm.value).subscribe(
      (res: any) => {
        if (res.token == '') {
          return;
        }
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        console.log(err);
      }
    );
  }
}
