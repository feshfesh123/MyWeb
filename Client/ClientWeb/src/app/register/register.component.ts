import { Component, OnInit } from '@angular/core';
import { UserRegistration } from '../shared/user.registration';
import { AuthService } from '../auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: UserRegistration = { fullname: '', email: '', password: ''};
  submitted: boolean = false;

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) {
   
  }

  ngOnInit() {
  }

  onSubmit() { 

    this.spinner.show();

    this.authService.register(this.userRegistration)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))  
      .subscribe(
      result => {         
         if(result) {
           this.success = true;
         }
      },
      error => {
        this.error = error;       
      });
  }

}
