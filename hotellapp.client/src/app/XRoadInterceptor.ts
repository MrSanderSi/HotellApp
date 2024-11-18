import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class XRoadInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const clonedRequest = req.clone({
      setHeaders: {
        'X-Road-Client': 'YOUR_CLIENT_IDENTIFIER',
        'X-Road-Id': 'YOUR_ID'
      }
    });
    return next.handle(clonedRequest);
  }
}
