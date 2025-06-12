import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  imports: [RouterLink, CommonModule, ReactiveFormsModule],
  templateUrl: './sign-in.html',
  styleUrl: './sign-in.css'
})
export class SignIn { 
  router = inject(Router);
  
  form = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [
      Validators.required,
      Validators.pattern(/^(\d{4})-\d{4}$/)
    ]),
    location: new FormControl('', [Validators.required]),
    about: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  async onSubmit() {
    if (this.form.valid) {
      this.router.navigate(['/login']);
    } else {
      console.error('Formulario inválido');
    }
  }
}
