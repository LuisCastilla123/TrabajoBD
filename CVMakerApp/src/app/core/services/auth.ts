import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { loginResponse, SignInRequest } from '../models/auth';
import { AppConfig } from '../confing/api';

@Injectable({
  providedIn: 'root'
})
export class Auth {
  private tokenKey = 'jwt_token';

  constructor(private http: HttpClient) { }

  async login(email: string, password: string): Promise<boolean> {
    try {   
      const response = await firstValueFrom(
        this.http.post<loginResponse>(`${AppConfig.apiUrl}/Auth/Login`, 
            {email, password,
        })
      );

      if (response?.token) {
        this.storeToken(response.token);
        return true;
      }

      return false;
    } catch (error) {
      console.error('Login failed:', error);
      return false;
    }
  }

  private storeToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUserId(): string | null {
  const token = this.getToken();

  if (!token) return null;

  try {
    // Decodificar el payload del token JWT
    const payload = JSON.parse(atob(token.split('.')[1]));

    // Priorizar userId sobre sub (que en tu caso contiene el ID del usuario)
    return payload.userId || payload.sub || null;
  } catch (e) {
    console.error('Error decoding token', e);
    return null;
  }
}

async signIn(userData: SignInRequest): Promise<void> {
  try {
    await firstValueFrom(
      this.http.post<void>(
        `${AppConfig.apiUrl}/Auth/SignIn`,
        userData
      )
    );
  } catch (error: any) {
    console.error('Sign in failed:', error);
    throw error;
  }
}



  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }
}
