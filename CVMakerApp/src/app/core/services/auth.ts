import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { loginResponse } from '../models/auth';
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

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }
}
