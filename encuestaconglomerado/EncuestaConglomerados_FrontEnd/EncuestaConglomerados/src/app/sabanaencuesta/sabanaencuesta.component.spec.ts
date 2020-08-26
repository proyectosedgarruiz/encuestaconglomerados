import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SabanaencuestaComponent } from './sabanaencuesta.component';

describe('SabanaencuestaComponent', () => {
  let component: SabanaencuestaComponent;
  let fixture: ComponentFixture<SabanaencuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SabanaencuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SabanaencuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
