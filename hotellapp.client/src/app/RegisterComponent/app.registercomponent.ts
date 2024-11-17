import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Validators, FormGroup, FormBuilder, AbstractControl, ValidationErrors } from '@angular/forms';

interface HotellRoom {
  id: string;
  roomNumber: number;
  bedCount: number;
  price: number;
  description: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.registercomponent.html',
  styleUrl: './app.registercomponent.css'
})

export class RegisterComponent implements OnInit {
  public rooms: HotellRoom[] = [];
  public searchForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.searchForm = this.fb.group({
      bookingStartDate: ['', Validators.required],
      bookingEndDate: ['', Validators.required],
    }, { validators: this.dateValidator });
  }

  ngOnInit() {
    this.getVacantRooms();
  }

  onSubmit() {
    if (this.searchForm.valid) {
      console.log(this.searchForm.value);
      this.getVacantRooms();
    } else {
      console.error('Form is invalid');
    }
  }

  getVacantRooms() {
    const formValues = this.searchForm.value;

    const startDate = formValues.bookingStartDate ?
      new Date(formValues.bookingStartDate).toISOString() :
      new Date(new Date().setDate(new Date().getDate() + 3)).toISOString();

    const endDate = formValues.bookingEndDate ?
      new Date(formValues.bookingEndDate).toISOString() :
      new Date(new Date().setDate(new Date().getDate() + 4)).toISOString();

    const params = new HttpParams()
      .set('StartDate', startDate)
      .set('EndDate', endDate);

    this.http.get<HotellRoom[]>('/HotellBooking/GetVacantRooms', { params }).subscribe(
      (result) => {
        console.log('Response:', result)
        this.rooms = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  goToRegistration(roomId: string) {
    this.router.navigate(['/registration', roomId]);
  }

  dateValidator(group: AbstractControl): ValidationErrors | null {
    const startDateControl = group.get('bookingStartDate');
    const endDateControl = group.get('bookingEndDate');

    if (!startDateControl || !endDateControl) {
      return null;
    }

    const startDate = new Date(startDateControl.value);
    const endDate = new Date(endDateControl.value);
    const cutoffDate = new Date();

    // minimum 3 days from now
    cutoffDate.setDate(cutoffDate.getDate() + 3)

    if (startDate < cutoffDate) {
      return { startDateInvalid: true };
    }

    if (endDate <= startDate) {
      return { endDateInvalid: true };
    }

    return null;
  }
}
