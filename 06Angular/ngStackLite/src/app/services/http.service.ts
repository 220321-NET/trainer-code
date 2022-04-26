import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { issue } from '../models/issue';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  //this is how angular does dependency injection
  constructor(private http: HttpClient) {

  }

  getAllQuestions() : Observable<any> {
    return this.http.get('https://stackliteapi.azurewebsites.net/api/Issues');
  }

  getQuestionById(id : number) : Observable<any> {
    return this.http.get(`https://stackliteapi.azurewebsites.net/api/Issues/${id}`);
  }

  createNewQuestion(q: Partial<issue>) : Observable<any> {
    return this.http.post('https://stackliteapi.azurewebsites.net/api/Issues', q);
  }
}