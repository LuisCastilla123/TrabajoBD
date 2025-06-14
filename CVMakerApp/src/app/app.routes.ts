import { Routes } from '@angular/router';
import { Login } from './presentation/login/login';
import { SignIn } from './presentation/sign-in/sign-in';
import { Cv } from './presentation/cv/cv';

export const routes: Routes = [
   {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login',
   },
   {path: 'login', component:Login}  ,
   {path: 'SignIn', component:SignIn},
   {path: 'cv', component: Cv}
];
