import { Injectable } from '@angular/core';
import { IEmployee, IDrink } from './employee';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http'
import { tap, catchError } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  drinksUrl: string = 'api/drinks';
  employeeUrl: string = 'api/employees';
  constructor(private http: HttpClient) { }

  getDrinks(): Observable<IDrink[]> {
    let params = new HttpParams().set("pageNumber",'1').set("pageSize", '10'); 
    return this.http.get<IDrink[]>(this.drinksUrl,{params:params}).pipe(
      tap(data => console.log('ALL' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  savePreference(employee : IEmployee): Observable<any> {
    return this.http.post<any>(this.employeeUrl, employee)
    .pipe(
      catchError(this.handleError)
    );
  }

  loadSetting(id : number): Observable<IEmployee> {
    return this.http.get<IEmployee>(`${this.employeeUrl}/${id}`)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {

    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = 'An error occured : ${err.error.message}'
    } else {
      errorMessage = 'Server error with status : ${err.status} and error : ${err.message}'
    }
    console.error(errorMessage)
    return throwError(errorMessage);
  }
}
