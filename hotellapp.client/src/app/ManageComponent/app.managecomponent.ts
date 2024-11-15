import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

interface HotellRoom {
  id: string;
  numberOfBeds: number;
  price: number;
  description: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.managecomponent.html',
  styleUrl: './app.managecomponent.css'
})

export class ManageComponent {
  public rooms: HotellRoom[] = [];
  public registrationForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.registrationForm = this.fb.group({
      idCode: ['', Validators.required],
      fullName: ['', Validators.required],
      bookingStartdate: ['', Validators.required],
      bookingEndDate: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      console.log(this.registrationForm.value);
    } else {
      console.error('Form is invalid');
    }
  }

  goToRegistration(roomId: string) {
    this.router.navigate(['/registration', roomId]);
  }

  title = 'hotellapp.client';
}
