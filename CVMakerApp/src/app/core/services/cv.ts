import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CVResponse, OptionsResponse, WorkExperienceRequest } from '../models/CV';
import { Auth } from './auth';
import { AppConfig } from '../confing/api';

@Injectable({
  providedIn: 'root'
})
export class CvService {
  constructor(
    private http: HttpClient,
    private auth: Auth
  ) {}

  async getCurrentUserCV(): Promise<CVResponse | null> {
    const userId = this.auth.getUserId();
    if (!userId) {
      console.error('No user ID found in token');
      return null;
    }

    return this.getCV(userId);
  }

  async getCV(userId: string): Promise<CVResponse | null> {
    try {
      const response = await firstValueFrom(
        this.http.get<CVResponse>(
          `${AppConfig.apiUrl}/CV/GetCV?userId=${userId}`,
          { headers: this.getAuthHeader() }
        )
      );
      return response;
    } catch (error) {
      console.error('Failed to fetch CV:', error);
      return null;
    }
  }

  async getOptions(): Promise<OptionsResponse> {
    const response = await firstValueFrom(
      this.http.get<OptionsResponse>(`${AppConfig.apiUrl}/Platform/GetOptions`)
    );
    return response;
  }

  async addSkill(skillId: string): Promise<boolean> {
    const userId = this.auth.getUserId();
        

    try {
      await firstValueFrom(
        this.http.post(
          `${AppConfig.apiUrl}/CV/AddSkill`,
          { userId, skillId },
          { headers: this.getAuthHeader() }
        )
      );
      return true;
    } catch (error) {
      console.error('Failed to add skill:', error);
      throw error;
    }
  }

  async addExperience(params: WorkExperienceRequest): Promise<boolean> {
    const userId = this.auth.getUserId();
    if (!userId) {
      console.error('No user ID found');
      return false;
    }

    const body = {
      ...params,
      userId
    };

    try {
      await firstValueFrom(
        this.http.post(
          `${AppConfig.apiUrl}/CV/AddExperience`,
          body,
          { headers: this.getAuthHeader() }
        )
      );
      return true;
    } catch (error) {
      console.error('Failed to add experience:', error);
      throw error;
    }
  }

  private getAuthHeader(): {[Headers: string]: string}{ 
    const token = this.auth.getToken();
    return token
      ? { Authorization : `Bearer ${token}` } : {};
  }
}
