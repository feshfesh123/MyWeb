import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserRegistration } from '../shared/user.registration';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

private returnUrl: string;

  constructor(private authService: AuthService, private spinner: NgxSpinnerService, private router: Router, 
    private activated: ActivatedRoute) { 
      this.activated.queryParams.subscribe(params => {
        this.returnUrl = params["returnUrl"];
    });
    }    

    userRegistration: UserRegistration = { fullname: '', email: '', password: ''};
    
    onSubmit() {     
      this.spinner.show();

      this.authService.login(this.userRegistration.email, this.userRegistration.password)
        .pipe(finalize(() => {
          this.spinner.hide();
        }))  
        .subscribe(() => {
          const url = this.returnUrl || '/';
          this.router.navigate([url]);
        }, (error) => {
          console.log(error)
      });
    }   

    ngOnInit() {
    }

}
