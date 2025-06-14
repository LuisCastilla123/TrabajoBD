import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../../core/services/auth';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sign-in',
  imports: [RouterLink, CommonModule, ReactiveFormsModule],
  templateUrl: './sign-in.html',
  styleUrl: './sign-in.css'
})  
export class SignIn { 
  router = inject(Router);
  singInService = inject(Auth);
  toastService = inject(ToastrService);
  
  form = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required,Validators.pattern(/^(\d{4})-\d{4}$/)]),
    location: new FormControl('', [Validators.required]),
    about: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  async onSubmit() {
    if (this.form.valid) {
      const rawValue = this.form.value;
      const userData = {
        userName: rawValue.userName ?? '', 
        email: rawValue. email?? '',
        phoneNumber : rawValue.phoneNumber ?? '',
        location: rawValue. location?? '',
        about: rawValue.about?? '',
        password: rawValue.password ?? '',
      };
      try{
        await this.singInService.signIn(userData);
        this.toastService.success('Regristro exitiso', 'Exito');
        this.router.navigate(['/login']);
      
    
    } catch(error) {
      console.error('Error al registrarse', error);
      const errorDescription =
      (typeof error === 'object' && error !== null && 'error' in error)
      ? (error as{error:{description? : string }}).error?.description : undefined;

      this.toastService.error(errorDescription || (typeof error === 'string' ? error :
        (error instanceof Error ? error.message : 'Ocurrio un error')),   
      );
    }
    }else {
      console.error('Formulario Invalido');
    }
    }
 }

