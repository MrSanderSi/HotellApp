import { HttpClient } from '@angular/common/http';
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

@Component({
  selector: 'app-root',
  templateUrl: './app.managecomponent.html',
  styleUrl: './app.managecomponent.css'
})

export class ManageComponent implements OnInit {
  public rooms: HotellRoom[] = [];
  public addRoomForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.addRoomForm = this.fb.group({
      roomNumber: ['', Validators.required],
      bedCount: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.getRooms();
  }

  getRooms() {
    this.http.get<HotellRoom[]>('/HotellBooking/GetAllRooms').subscribe(
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
      const newRoom: HotellRoom = this.addRoomForm.value;
      this.http.post('/HotellBooking/AddRoom', newRoom).subscribe(
        () => {
          this.getRooms(); // Refresh the list of rooms
        },
        (error) => {
          console.error(error);
        }
      );
    } else {
      console.error('Form is invalid');
    }
  }

  deleteRoom(roomId: string) {
    this.http.delete(`/HotellBooking/DeleteRoom/${roomId}`).subscribe(
      () => {
        this.getRooms(); // Refresh the list of rooms
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
