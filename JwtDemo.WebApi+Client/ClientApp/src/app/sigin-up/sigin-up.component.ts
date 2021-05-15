import { Component, Injectable, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NotifierService } from "angular-notifier";
//import { ConsoleReporter } from 'jasmine';
import { NgxSpinnerService } from "ngx-spinner";
import { SiginUpModel } from "../models/sigin-up.model";
import { AuthService } from "../Services/auth.service";

@Component({
  selector: "sigin-up",
  templateUrl: "./sigin-up.component.html",
  styleUrls: ["./sigin-up.component.css"],
})
export class SiginUpComponent implements OnInit {
  model = new SiginUpModel();
  confirmPassword: string;

  constructor(
    private spinner: NgxSpinnerService,
    private notifier: NotifierService,
    private auth: AuthService,
    private router: Router
  ) {}

  register() {
    this.spinner.show();
    this.notifier.hideAll();

    console.log(this.model);

    if (
      this.model.FullName == "" ||
      this.model.Address == "" ||
      this.model.Email == "" ||
      this.model.Password == "" ||
      this.model.Phone == "" ||
      this.confirmPassword == ""
    ) {
      this.spinner.hide();
     // this.notifier.hideAll();
      this.notifier.notify("warning", "Please complete all gaps");
    } else {
      if (this.model.Password != this.confirmPassword) {
        this.spinner.hide();
     //   this.notifier.hideAll();
        this.notifier.notify("error", "Your password isn't confirmed");
      } else {
        this.auth.signUp(this.model).subscribe((data) => {
          console.log("data:");
          console.log(data);
          if (data.statusCode === 200) {
            this.spinner.hide();
            this.router.navigate(["/sign-in"]);
          } else if (data.statusCode === 500) {
            this.spinner.hide();
            this.notifier.hideAll();
            if (this.model.Password.length > 5) {
              this.notifier.notify(
                "error",
                "Registration problem. There is registered user with the same email"
              );
            } else {
              this.notifier.notify(
                "error",
                "Registration problem. Your password must contains more than 5 symbols"
              );
            }
          }
        });
      }
    }
  }

  ngOnInit() {}
}
