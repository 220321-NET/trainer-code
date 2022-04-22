import { Component, OnInit, Output } from '@angular/core';

interface charAttempt {
  char: string;
  color: string;
}

@Component({
  selector: 'game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.css']
})
export class GameBoardComponent implements OnInit {

  constructor() { }

  answer: string = 'SHEEP'
  attempts: string[] = []
  maxAttempt: number = 5
  currAttempt: number = 0
  display: {[index: string]: charAttempt} = {
  }

  keyPressed(key: string)
  {
    if(this.currAttempt > this.maxAttempt) return;

    if(this.attempts[this.currAttempt]) this.attempts[this.currAttempt] += key; 
    else this.attempts[this.currAttempt] = key;

    this.display[this.currAttempt+ 'c' + (this.attempts[this.currAttempt].length - 1)].char = key;

    if(this.attempts[this.currAttempt]?.length == 5)
    {
      this.checkAnswer();
    }
    console.log(this.attempts);
  }

  checkAnswer()
  {
    let attempt = this.attempts[this.currAttempt];
    let correct: boolean = this.answer == attempt;

    for(let i = 0; i < this.answer.length; i++)
    {
      if(this.answer[i] == attempt[i])
      {
        //it's green!
        this.display[this.currAttempt + 'c' + i].color = 'green';
      }
      else if(this.answer.indexOf(attempt[i]) > -1)
      {
        //it's a yellow!
        this.display[this.currAttempt + 'c' + i].color = 'yellow';
      }
      else
      {
        //whomp whomp...
        this.display[this.currAttempt + 'c' + i].color = 'grey';
      }
    }

    correct ? this.currAttempt = 6 : this.currAttempt++;
    return correct;
  }
  ngOnInit(): void {
    for(let i = 0; i < 6; i++)
    {
      for(let j = 0; j < 5; j++)
      {
        this.display[i + 'c' + j] = {
          char: '',
          color: ''
        }
      }
    }
  }
}
