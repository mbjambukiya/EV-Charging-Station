import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvSitesComponent } from './ev-sites.component';

describe('EvSitesComponent', () => {
  let component: EvSitesComponent;
  let fixture: ComponentFixture<EvSitesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EvSitesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EvSitesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
