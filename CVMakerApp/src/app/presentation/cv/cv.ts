import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { Auth } from '../../core/services/auth';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AddSkill } from './components/add-skill';
import { AddWorkExperience } from './components/add-work-experience';
import { CvService } from '../../core/services/cv';
import { CVResponse, OptionDTO, OptionsResponse } from '../../core/models/CV';

@Component({
  selector: 'app-cv',
  imports: [CommonModule, AddSkill, AddWorkExperience],
  templateUrl: './cv.html',
  styleUrl: './cv.css'
})
export class Cv implements OnInit {

  showAddSkill = false;
  showAddExperience = false;

  cv: CVResponse = {
    user: {
      userId: '',
      userName: '',
      email: '',
      phoneNumber: '',
      userInfo: {
        location: '',
        about: '',
        skills: [],
        languages: []
      },
      academicHistories: [],
      workExperiences: []
    },
    updatedAt: new Date()
  };

  globalOptions: OptionsResponse = {} as OptionsResponse;

  authService = inject(Auth);
  router = inject(Router);
  cvService = inject(CvService);
  cdr = inject(ChangeDetectorRef);

  loadOptions() {
    this.cvService.getOptions().then(options => {
      this.globalOptions = options;
      console.log('Global options loaded:', options);
    }).catch(error => {
      console.error('Error loading global options:', error);
    });
  }

  loadCV() {
    this.cvService.getCurrentUserCV().then(cv => {
      if (!cv) {
        console.error('No CV found for the current user');
        return;
      }
      this.cv = cv;
      this.cdr.detectChanges();
      console.log('CV loaded:', cv);
    }).catch(error => {
      console.error('Error loading CV:', error);
    });
  }

  ngOnInit() {
    this.loadCV();
    this.loadOptions();
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  getUserInitials(): string {
    const name = this.cv.user.userName || '';
    if (!name) return '';
    const parts = name.split(' ');
    if (parts.length === 0) return '';
    return parts.map(part => part.charAt(0).toUpperCase()).join('');
  }

  onSkillAdded(newSkill: OptionDTO) {
    this.cv.user.userInfo!.skills!.push(newSkill);
    this.showAddSkill = false;
  }

  onExperienceAdded() {
    this.showAddExperience = false;
    this.loadCV();
  }
}
