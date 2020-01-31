import { TestBed } from '@angular/core/testing';

import { BookwormService } from './bookworm.service';

describe('BookwormService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BookwormService = TestBed.get(BookwormService);
    expect(service).toBeTruthy();
  });
});
