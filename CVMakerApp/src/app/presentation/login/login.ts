import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule,FormControl, FormGroup, Validators,} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../../core//services/auth';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class Login {
  router = inject(Router);
  authService = inject(Auth);
  toastr = inject(ToastrService);

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  async onSubmit() {
    if (this.form.valid) {
      const { email, password } = this.form.value;
      const success = await this.authService.login(email!, password!);
      if (success) {
        this.router.navigate(['/cv']);
      } else {
        this.toastr.error('Credenciales inválidas', 'Error');
      }
    } else {
      console.log('Formulario inválido');
    }
  }
}
