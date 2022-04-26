import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpService } from 'src/app/services/http.service';
import { issue } from '../../models/issue';
import { Router } from '@angular/router';
@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.css']
})
export class NewQuestionComponent implements OnInit {

  newQuestion : issue = {
    Answers : [],
    Content : '',
    DateCreated : new Date(),
    Id : 0,
    Score : 0,
    Title : ''
  }

  constructor(private api : HttpService, private router : Router) { }

  ngOnInit(): void {
  }

  submitForm() {
    this.newQuestion.DateCreated = new Date();
    this.api.createNewQuestion(this.newQuestion).subscribe((res) => {
      this.router.navigate([''])
    })
  }

}
