import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NgxNotifierService } from "ngx-notifier";
import { NgxSpinnerService } from "ngx-spinner";
import { NgxSpinner } from "ngx-spinner/lib/ngx-spinner.enum";
import { SiginInModel } from "../models/sigin-in.model";
import { AuthService } from "../Services/auth.service";
import jwt_decode from "jwt-decode";
import { NotifierService } from "angular-notifier";
import { decode } from "querystring";
@Component({
  selector: "sigin-in",
  templateUrl: "./sigin-in.component.html",
  styleUrls: ["./sigin-in.component.css"],
})
export class SiginInComponent implements OnInit {
  constructor(
    private auth: AuthService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService,
    private router: Router
  ) {}

  model = new SiginInModel();

  login() {
    if (this.model.Password == "" || this.model.Email == "") {
      this.notifier.hideAll();
      this.notifier.notify("error", "Please complete all gaps");
    } else {
      this.spinner.show();
      this.auth.signIn(this.model).subscribe((data) => {
        console.log("data responce sign in:");
        console.log(data);
        if (data.statusCode === 200) {
          this.notifier.hideAll();
          this.spinner.hide();
         // this.router.navigate([""]);
          window.localStorage.setItem("token", data.token);
          var decoded = jwt_decode(data.token);

          console.log(decoded);
          if (decoded["role"] == "Admin") {
            this.router.navigate(["/admin-pannel"]);
          } else {
            this.router.navigate(["/client-area"]);
          }
        } else if (data.statusCode === 402) {
          this.spinner.hide();
          this.notifier.hideAll();
          this.notifier.notify("error", "Login or password error");
        }
      });
    }
  }
  ngOnInit() {}
}
