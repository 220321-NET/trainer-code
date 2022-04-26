import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { issue } from 'src/app/models/issue';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-question-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private api: HttpService, private router: Router) { }

  allQuestions : issue[] = []

  //this is an example of lifecycle hook
  ngOnInit(): void {
    //i can put my initialization behaviors here

    this.api.getAllQuestions().subscribe((res : issue[]) => {
      this.allQuestions = res;
    })
  }

  navigateToDetails(id : number) : void {
    this.router.navigate(['question', id]);
  }

}
