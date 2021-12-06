import { Component, OnInit } from "@angular/core";
import { RouterExtensions } from "@nativescript/angular";
import { SnackBar } from "nativescript-snackbar";
import { Login } from "../../proxy/Login";
import { AutheticationService } from "../../services/authetication.service";
import * as storage from "@nativescript/core/application-settings";

@Component({
  moduleId: module.id,
  selector: "login",
  templateUrl: "login.component.html",
  providers: [AutheticationService],
})
export class LoginComponent implements OnInit {
  public login: Login = new Login();

  constructor(
    private router: RouterExtensions,
    private autheticationService: AutheticationService
  ) {}

  public ngOnInit() {
    console.log("testi");
  }

  public attemptLogin(): void {
    this.autheticationService.test().subscribe((value) => {
      console.log(value);
    });

    if (this.login.email !== "" && this.login.password !== "") {
      this.autheticationService.login(this.login).subscribe(
        (token) => {
          console.log(token);
          storage.setString("authToken", token);
          this.router.navigate(["/home"], { clearHistory: true });
        },
        (err) => {
          console.log(err);
          //new SnackBar().simple("Incorrect Credentials!");
        }
      );
    }
  }
}
