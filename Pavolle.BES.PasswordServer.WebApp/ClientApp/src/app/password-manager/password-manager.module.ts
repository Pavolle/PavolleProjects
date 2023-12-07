import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPasswordComponent } from './list-password/list-password.component';
import { AddPasswordComponent } from './add-password/add-password.component';
import { EditPasswordComponent } from './edit-password/edit-password.component';
import { DetailPasswordComponent } from './detail-password/detail-password.component';
import { ShowPasswordComponent } from './show-password/show-password.component';



@NgModule({
  declarations: [
    ListPasswordComponent,
    AddPasswordComponent,
    EditPasswordComponent,
    DetailPasswordComponent,
    ShowPasswordComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PasswordManagerModule { }
