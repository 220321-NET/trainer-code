import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailComponent } from './question/detail/detail.component';
import { ListComponent } from './question/list/list.component';
import { NewQuestionComponent } from './question/new-question/new-question.component';

const routes: Routes = [
  {
    path: 'question/:id',
    component: DetailComponent
  },
  {
    path: 'create',
    component: NewQuestionComponent
  },
  {
    path: '',
    component: ListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
