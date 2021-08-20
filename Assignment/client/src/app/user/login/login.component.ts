import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public user: FormGroup;
  public errorMessage: string = '';

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.user = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    this.authService.login(this.user.value.username, 
            this.user.value.password).subscribe(
      val => {
        if (val) {
          if (this.authService.redirectUrl) {
            this.router.navigateByUrl(this.authService.redirectUrl);
            this.authService.redirectUrl = undefined;
          } else {
            this.router.navigate(['/']);
          }
        }
        }, 
        (err: HttpErrorResponse) => {
        console.log(err);
        if (err.error instanceof Error) {
          this.errorMessage = `Error while trying to login user ${this.user.value.email}: ${err.error.message}`;
        } else {
          this.errorMessage = `Error ${err.status} while trying to login user ${this.user.value.email}: ${err.error}`;
        }
      });
      
    }

}
