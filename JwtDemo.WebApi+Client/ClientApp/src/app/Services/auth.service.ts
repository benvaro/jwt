import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiResponce } from "../models/api-responce.model";
import { SiginInModel } from "../models/sigin-in.model";
import { SiginUpModel } from "../models/sigin-up.model";
@Injectable({ providedIn: "root" })
export class AuthService {
  baseUrl = "https://localhost:44336/api/Account";
  constructor(private http: HttpClient) {}

  signUp(model: SiginUpModel): Observable<ApiResponce> {
    return this.http.post<ApiResponce>(this.baseUrl + "/register", model);
  }

  signIn(model: SiginInModel): Observable<ApiResponce> {
    return this.http.post<ApiResponce>(this.baseUrl + "/login", model);
  }
}
