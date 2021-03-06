import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }


  login(username: string, password: string): Observable<any> {
    //return this.http.post<any>(`http://api.shiningbeautysalon.com/Authentication/Login`, null,
    return this.http.post<any>(`https://localhost:44355/Authentication/Login`, null,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
        params: { username: username, password: password }
      },
    );
  }
}
