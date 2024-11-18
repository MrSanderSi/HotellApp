import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-booking',
  templateUrl: './app.bookingcomponent.html',
  styleUrls: ['./app.bookingcomponent.css']
})
export class BookingComponent implements OnInit {
  public bookingForm: FormGroup;
  public roomId: string | null = null;
  public startDate: Date | null = null;
  public endDate: Date | null = null;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
    this.bookingForm = this.fb.group({
      name: ['', Validators.required],
      idCode: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.roomId = this.route.snapshot.paramMap.get('id');
    const startDateStr = this.route.snapshot.queryParamMap.get('startDate');
    const endDateStr = this.route.snapshot.queryParamMap.get('endDate');

    if (startDateStr) {
      this.startDate = new Date(startDateStr);
    }
    if (endDateStr) {
      this.endDate = new Date(endDateStr);
    }
  }

  onSubmit(): void {
    if (this.bookingForm.valid && this.roomId) {
      const bookingData = {
        ...this.bookingForm.value,
        roomId: this.roomId,
        startDate: this.startDate,
        endDate: this.endDate
      };

      this.http.post('/api/v1/hotellbooking/bookings', bookingData).subscribe(
        () => {
          alert('Booking successful!');
          this.router.navigate(['/']);
        },
        (error) => {
          console.error('Booking failed', error);
          alert('Booking failed. Please try again.');
        }
      );
    } else {
      console.error('Form is invalid');
    }
  }
}
