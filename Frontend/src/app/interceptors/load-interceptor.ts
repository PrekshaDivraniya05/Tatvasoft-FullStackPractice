import { HttpInterceptorFn } from '@angular/common/http';
import { catchError, finalize, throwError } from 'rxjs';

export const loadInterceptor: HttpInterceptorFn = (req, next) => {
  debugger;
  console.log('Request Started');

  return next(req).pipe(
    catchError(error => {
      debugger;
      console.error('Error:', error);
      return throwError(() => error);
    }),
    finalize(() => {
      debugger;
      console.log('Request Finished');
    })
  )
}

