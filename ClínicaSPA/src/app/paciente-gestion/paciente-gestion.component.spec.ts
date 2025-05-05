import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacienteGestionComponent } from './paciente-gestion.component';

describe('PacienteGestionComponent', () => {
  let component: PacienteGestionComponent;
  let fixture: ComponentFixture<PacienteGestionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PacienteGestionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PacienteGestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
