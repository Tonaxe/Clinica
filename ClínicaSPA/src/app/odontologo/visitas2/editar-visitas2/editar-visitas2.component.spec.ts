import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarVisitas2Component } from './editar-visitas2.component';

describe('EditarVisitas2Component', () => {
  let component: EditarVisitas2Component;
  let fixture: ComponentFixture<EditarVisitas2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditarVisitas2Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarVisitas2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
