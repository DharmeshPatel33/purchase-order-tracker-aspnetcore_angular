import { TestBed } from '@angular/core/testing';
import { RouteNotFoundComponent } from './route-not-found.component';

describe('RouteNotFoundComponent', () => {
  it('constructs', () => {
    TestBed.configureTestingModule({
      declarations: [RouteNotFoundComponent]
    });
    const fixture = TestBed.createComponent(RouteNotFoundComponent);
    const component = fixture.componentInstance;
    expect(component).toBeDefined();
  });
});
