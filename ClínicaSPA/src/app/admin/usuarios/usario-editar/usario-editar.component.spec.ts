import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsarioEditarComponent } from './usario-editar.component';

describe('UsarioEditarComponent', () => {
  let component: UsarioEditarComponent;
  let fixture: ComponentFixture<UsarioEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UsarioEditarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsarioEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
