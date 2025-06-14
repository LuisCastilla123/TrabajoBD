import { Component, EventEmitter, Output, Input, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { OptionDTO } from '../../../core/models/CV';
import { CvService } from '../../../core/services/cv';

@Component({
    selector: 'app-add-work-experience',
    template:` 
    <div class="fixed inset-0 z-50 flex items-center justify-center" style="background-color: rgba(0, 0, 0, 0.5);">
        <!-- Modal content -->
        <div class="bg-white p-6 rounded-lg shadow-lg w-full max-w-md relative">
            <h3 class="text-lg font-semibold mb-4">Añadir Experiencia Laboral</h3>
            <div class="space-y-4">
                <div>
                <label class="block text-sm font-medium text-gray-700">Empresa</label>
                <input [(ngModel)]="enterpriseName" type="text" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm">
                </div>
                <div>
                <label class="block text-sm font-medium text-gray-700">Puesto</label>
                <select [(ngModel)]="jobTitleId" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm">
                    <option value="">-- Selecciona un puesto --</option>
                    <option *ngFor="let job of availableJobTitles" [value]="job.id">{{ job.name }}</option>
                </select>
                </div>
                <div class="grid grid-cols-2 gap-4">
                <div>
                    <label class="block text-sm font-medium text-gray-700">Fecha Inicio</label>
                    <input [(ngModel)]="startDate" type="date" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm">
                </div>
                <div>
                    <label class="block text-sm font-medium text-gray-700">Fecha Fin</label>
                    <input [(ngModel)]="endDate" type="date" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm">
                </div>
                </div>
                <div>
                <label class="block text-sm font-medium text-gray-700">Descripción</label>
                <textarea [(ngModel)]="description" rows="3" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm"></textarea>
                </div>
                <div class="flex justify-end space-x-2">
                <button (click)="onCancel()" type="button" class="px-4 py-2 border rounded-md">Cancelar</button>
                <button (click)="onAddExperience()" type="button" class="px-4 py-2 bg-indigo-600 text-white rounded-md">
                    Añadir
                </button>
                </div>
            </div>
        </div>
    </div>
    `,

    standalone : true,
    imports : [FormsModule, CommonModule],
})

export class AddWorkExperience {

  @Input() availableJobTitles: OptionDTO[] = [];
  @Output() experienceAdded = new EventEmitter<void>();
  @Output() canceled = new EventEmitter<void>();

  enterpriseName: string = '';
  jobTitleId: string = '';
  startDate: string = new Date().toISOString().split('T')[0];
  endDate: string | undefined;
  description: string = '';

  cvService = inject(CvService);
  toastService = inject(ToastrService);

  async onAddExperience() {
    if (!this.enterpriseName.trim() || !this.jobTitleId) {
      this.toastService.error('Por favor, completa todos los campos obligatorios.', 'Error');
      return;
    }

    try {
      const success = await this.cvService.addExperience({
        enterpriseName: this.enterpriseName.trim(),
        startDate: this.startDate,
        endDate: this.endDate || this.startDate,
        description: this.description.trim(),
        jobTitleId: this.jobTitleId
      });

      if (success) {
        this.experienceAdded.emit();
        this.resetForm();
        this.toastService.success('Experiencia laboral añadida correctamente', 'Éxito');
      }
    } catch (error) {
      console.error('Error al añadir la experiencia laboral:', error);
      const errorDescription =
        (typeof error === 'object' && error !== null && 'error' in error)
          ? (error as { error: {description?: string }}).error?.description: undefined;

      this.toastService.error(errorDescription || (typeof error === 'string' ? error : 'Ocurrio un error ')),
      'Error'
    
    }
  }

  onCancel() {
    this.canceled.emit();
  }

  private resetForm() {
    this.enterpriseName = '';
    this.jobTitleId = '';
    this.startDate = new Date().toISOString().split('T')[0];
    this.endDate = undefined;
    this.description = '';
  }
}

