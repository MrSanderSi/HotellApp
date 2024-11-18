import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

interface HotellRoom {
  id: string;
  roomNumber: number;
  bedCount: number;
  price: number;
  description: string;
}

interface Booking {
  id: string;
  roomId: string;
  personId: string;
  startDate: string;
  endDate: string;
  roomNumber: number;
  name: string;
  email: string;
  phone: string;
  totalPrice: number;
  };

@Component({
  selector: 'app-root',
  templateUrl: './app.managecomponent.html',
  styleUrl: './app.managecomponent.css'
})

export class ManageComponent implements OnInit {
  public rooms: HotellRoom[] = [];
  public bookings: Booking[] = [];
  public addRoomForm: FormGroup;
  public searchBookingsForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.addRoomForm = this.fb.group({
      roomNumber: ['', Validators.required],
      bedCount: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required]
    });

    this.searchBookingsForm = this.fb.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.getRooms();
  }

  getRooms() {
    this.http.get<HotellRoom[]>('/api/v1/hotellbooking/rooms').subscribe(
      (result) => {
        this.rooms = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onSubmit() {
    if (this.addRoomForm.valid) {
      const roomData = this.addRoomForm.value;

      this.http.post('/api/v1/hotellbooking/rooms', roomData).subscribe(
        () => {
          this.getRooms();
          this.addRoomForm.reset();
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  deleteRoom(roomId: string) {
    this.http.delete(`/api/v1/hotellbooking/rooms/${roomId}`).subscribe(
      () => {
        this.getRooms(); // Refresh the list of rooms
      },
      (error) => {
        console.error(error);
      }
    );
  }

  searchBookings() {
    if (this.searchBookingsForm.valid) {
      const formValues = this.searchBookingsForm.value;
      const params = new HttpParams()
        .set('startDate', new Date(formValues.startDate).toISOString())
        .set('endDate', new Date(formValues.endDate).toISOString());

      this.http.get<Booking[]>('/api/v1/hotellbooking/bookings', { params }).subscribe(
        (result) => {
          this.bookings = result;
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  cancelBooking(bookingId: string) {
    this.http.delete(`/api/v1/hotellbooking/bookings/${bookingId}`).subscribe(
      () => {
        this.searchBookings(); // Refresh the list of bookings
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
