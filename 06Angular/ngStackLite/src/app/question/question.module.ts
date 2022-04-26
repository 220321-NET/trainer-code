import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NewQuestionComponent } from './new-question/new-question.component';
import { DetailComponent } from './detail/detail.component';

@NgModule({
  declarations: [
    ListComponent,
    NewQuestionComponent,
    DetailComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  exports: [
    ListComponent,
    NewQuestionComponent,
    DetailComponent
  ]
})
export class QuestionModule { }
