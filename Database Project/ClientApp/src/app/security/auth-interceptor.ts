import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth-service.service";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token = this.authService.getToken();
    if (token) {
      var header = "Bearer " + token;
      var reqWithAuth = req.clone({ headers: req.headers.set("Authorization", header) });
      return next.handle(reqWithAuth);
    }

    return next.handle(req);
  }
}
