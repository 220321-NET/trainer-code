import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { issue } from 'src/app/models/issue';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  constructor(private api: HttpService, private activatedRoute : ActivatedRoute) { }

  id = 1;

  question : issue = {
    Answers: [],
    Content: '',
    DateCreated: new Date(),
    Id : 0,
    Score : 0,
    Title : ''
  }
  ngOnInit(): void {
    //Watch out for race condition
    this.activatedRoute.params.subscribe(params => {
      
      this.api.getQuestionById(params['id']).subscribe((res : issue) => {
        this.question = res;
      })
    })
  }

}
