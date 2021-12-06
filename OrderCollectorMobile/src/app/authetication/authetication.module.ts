import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "@nativescript/angular";
import { AutheticationRoutingModule } from "./authetication-routing.module";
import { NativeScriptFormsModule } from "@nativescript/angular";
import { LoginComponent } from "./login/login.component";
import { NativeScriptHttpClientModule } from "@nativescript/angular";

@NgModule({
  imports: [
    NativeScriptCommonModule,
    AutheticationRoutingModule,
    NativeScriptFormsModule,
    NativeScriptHttpClientModule,
  ],
  declarations: [LoginComponent],
  schemas: [NO_ERRORS_SCHEMA],
})
export class autheticationModule {}
