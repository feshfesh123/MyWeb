import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from './shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService{
  private url: string = 'http://tftbidentity20191120113552.azurewebsites.net';

  constructor(private http:HttpClient, private jwtHelper: JwtHelperService) {super(); }
  
  
  login(email: string, password: string): Observable<any> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let body = new URLSearchParams();
    body.set('username', email);
    body.set('password', password);
    body.set('grant_type', "password");
    body.set('client_id', "client");
    body.set('client_secret', "secret");

    return this.http.post<any>(this.url + '/connect/token', body.toString(), {
      headers: headers
    }).pipe(
      map(jwt => {
        if (jwt && jwt.access_token) {
          localStorage.setItem('token', JSON.stringify(jwt))
        }
      })
    );
  }

  register(userRegistration: any) {    
    return this.http.post(this.url + '/api/account', userRegistration).pipe(catchError(this.handleError));
  }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  getToken() {
    return this.jwtHelper.tokenGetter();
  }

  logout() {
    localStorage.removeItem('token');
  }
}

