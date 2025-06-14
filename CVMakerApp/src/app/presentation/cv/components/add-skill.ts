import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { CvService } from '../../../core/services/cv';
import { OptionDTO } from '../../../core/models/CV';

@Component({
  selector: 'app-add-skill',
  standalone: true,
  template: ` 
    <!-- Modal overlay -->
    <div class="fixed inset-0 z-50 flex items-center justify-center" style="background-color: rgba(0, 0, 0, 0.5);">
      <!-- Modal content -->
      <div class="bg-white p-6 rounded-lg shadow-lg w-full max-w-md relative">
        <h3 class="text-lg font-semibold mb-4">Añadir Nueva Habilidad</h3>
        <div class="space-y-4">
          <div>
            <select [(ngModel)]="selectedSkillId" class="mt-1 block w-full rounded-md border-gray-300 shadow-sm">
              <option value="">Selecciona una habilidad</option>
              <option *ngFor="let skill of availableSkills" [value]="skill.id">
                {{ skill.name }}
              </option>
            </select>
          </div>

          <div class="flex justify-end space-x-2 pt-4">
            <button (click)="onCancel()" type="button" class="px-4 py-2 border rounded-md">Cancelar</button>
            <button (click)="onAddSkill()" type="button" class="px-4 py-2 bg-indigo-600 text-white rounded-md">
              Añadir
            </button>
          </div>
        </div>
      </div>
    </div>
  `,
  imports: [FormsModule, CommonModule]
})
export class AddSkill {
  @Input() availableSkills: OptionDTO[] = [];
  @Output() skillAdded = new EventEmitter<OptionDTO>();
  @Output() canceled = new EventEmitter<void>();

  private cvService = inject(CvService);
  private toastService = inject(ToastrService);

  selectedSkillId: string = '';

  onAddSkill(): void {
    if (this.selectedSkillId){ 

    const selectedSkill = this.availableSkills.find(skill => skill.id === this.selectedSkillId);
    if (selectedSkill) { 
    this.cvService.addSkill(selectedSkill.id).then(success => {
      if (success) {
        this.toastService.success('Habilidad añadida correctamente', 'Éxito');
        this.skillAdded.emit(selectedSkill);
        this.resetForm();
      } else {
        console.error('No se pudo añadir la habilidad'  );
      }
    }).catch(error =>{
        console.error('Error al añadir Habilidad: ', error);
      const errorDescription =
        (typeof error === 'object' &&  error !==null && 'error' in error)
        ?(error as { error:{ description?:  string}}).error?.description: undefined;

        this.toastService.error(errorDescription || (typeof error == 'string' ? error:(
            error instanceof Error? error.message : 'Ocurrio un error'
        )), 'Error');
    });
    this.resetForm();
  }
  }
}

  onCancel(): void {
    this.canceled.emit();
    this.resetForm();
  }

  private resetForm(): void {
    this.selectedSkillId = '';
  }
}

