import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NativeScriptRouterModule } from "@nativescript/angular";

const routes: Routes = [
  { path: "", redirectTo: "/authetication", pathMatch: "full" },
  {
    path: "home",
    loadChildren: () =>
      import("~/app/home/home.module").then((m) => m.HomeModule),
  },
  {
    path: "authetication",
    loadChildren: () =>
      import("~/app/authetication/authetication.module").then(
        (m) => m.autheticationModule
      ),
  },
];

@NgModule({
  imports: [NativeScriptRouterModule.forRoot(routes)],
  exports: [NativeScriptRouterModule],
})
export class AppRoutingModule {}
