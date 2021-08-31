import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: [
    'login.component.scss'
  ],
  providers: [
    LoginService
  ]
})

export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService
  ) { }

  ngOnInit() { 
    this.form = this.fb.group({
      userName: [null, Validators.required],
      password: [null, Validators.required],
    })
  }

  login() {
    if (!this.form.valid) {
      return;
    }

    this.loginService.login(this.form.value.userName, this.form.value.password);
  }
}