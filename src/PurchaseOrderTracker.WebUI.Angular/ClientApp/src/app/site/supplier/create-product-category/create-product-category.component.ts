import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { MessagesService } from '../../shared/messages/messages.service';
import { CreateProductCategoryCommand, CreateProductCategoryService } from './create-product-category.service';

@Component({
  templateUrl: './create-product-category.component.html'
})
export class CreateProductCategoryComponent {
  @Input() supplierId: number;
  objectKeys = Object.keys;
  model = new CreateProductCategoryViewModel();

  constructor(
    public activeModal: NgbActiveModal,
    private createProductCategoryService: CreateProductCategoryService,
    private messagesService: MessagesService
  ) {}

  onSubmit() {
    const command = new CreateProductCategoryCommand(this.supplierId, this.model.name);
    this.createProductCategoryService
      .handle(command)
      .subscribe(
        () => this.activeModal.close('Product category created'),
        err => this.messagesService.addHttpResponseError(err)
      );
  }
}

export class CreateProductCategoryViewModel {
  name: string;
}
