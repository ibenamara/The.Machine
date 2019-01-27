import { Component, OnInit } from '@angular/core';
import { EmployeesService } from './employees.service';
import { IDrink, IEmployee, IEmployeePrefence } from './employee';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  private drinks: IDrink[];
  private employee: IEmployee;
  private rememberMe: boolean;
  private badgeId : number;
  private settingLoaded : boolean;
  private errorMessage: string;

  constructor(private employeeService: EmployeesService, private toastr: ToastrService) {
    this._initEmployee();
  }

  private _initEmployee() {
    this.employee = new IEmployee();
    this.employee.Preference = new IEmployeePrefence();
    this.employee.Preference.Drink = new IDrink();
    this.rememberMe = false;
    this.badgeId = null;
    this.settingLoaded = false;
  }
  
  clear() {
    this._initEmployee();
  }

  makeDrink() {
    if (this.rememberMe) {

      this.employeeService.savePreference(this.employee).subscribe(
        () =>
          this.toastr.success('A Bientôt', 'Votre boisson est prête!'),
        (error) => this.toastr.error('Une erreur s\'est produite', error.message));
      this._initEmployee();
    } else {
      this.toastr.success('A Bientôt', 'Votre boisson est prête!');
      this._initEmployee();
    }
  }
  loadSetting(){
    this.employeeService.loadSetting(this.badgeId).subscribe(
      (employee) => {
        this.rememberMe = true;
        this.settingLoaded = true;
        this.employee = employee;
        this.toastr.success('Vous pouvez commander votre boisson', 'Chargement Effectué');
      },
      (error) => this.toastr.error('Une erreur s\'est produite', error.message));
  }
  ngOnInit() {
    this.employeeService.getDrinks().subscribe(
      drinks => {
        this.drinks = drinks
      },
      error => this.errorMessage = error
    );
  }
}
