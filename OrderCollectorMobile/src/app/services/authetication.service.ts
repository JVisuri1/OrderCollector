import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { appConfig } from "../app.config";

import { Login } from "../proxy/Login";

@Injectable({
  providedIn: "root",
})
export class AutheticationService {
  constructor(private http: HttpClient) {}

  public login(login: Login): Observable<string> {
    let options = this.createRequestOptions();
    return this.http.post<string>(
      appConfig.apiUrl + "Authetication/login",
      login,
      { headers: options }
    );
  }

  public test(): Observable<any> {
    let options = this.createRequestOptions();
    return this.http.get(appConfig.apiUrl + "order/getorders", {
      headers: options,
    });
  }

  private createRequestOptions() {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
    });
    return headers;
  }
}
