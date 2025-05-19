import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Visitas2Component } from './visitas2.component';

describe('Visitas2Component', () => {
  let component: Visitas2Component;
  let fixture: ComponentFixture<Visitas2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Visitas2Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Visitas2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
