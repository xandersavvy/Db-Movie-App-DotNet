import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs ';
const handleError = (error: HttpErrorResponse) => {
  // return Observable.throw(error.message || 'Server Error');
};

export default handleError;
