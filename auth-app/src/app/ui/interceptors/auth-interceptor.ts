import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { RegistrationService } from '../services/registration.service';



@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    // contentType: string = 'Content-Type';
    // valueJson: string = 'application/json';

    constructor(registrService: RegistrationService) { }


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        let tokenValue = JSON.parse(localStorage.getItem('access_token'));
        let tokenType = JSON.parse(localStorage.getItem('token_type'));
        let refreshToken ;
        // = JSON.parse(localStorage.getItem('refresh_token'));

        if (localStorage.getItem('access_token') && localStorage.getItem('token_type')) {
            req = req.clone({
                headers: req.headers

                    .set("Authorization", tokenType + " " + tokenValue)
                    // .set("refresh_token", refreshToken)
            });
        }

        alert(tokenValue);
        alert(refreshToken);

        return next.handle(req);
    }
}
