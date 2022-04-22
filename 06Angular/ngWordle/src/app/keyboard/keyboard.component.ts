import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css']
})
export class KeyboardComponent implements OnInit {

  constructor() { }

  @Output() virtualKeyEvent = new EventEmitter();

  keyClick(e: Event) {
    this.virtualKeyEvent.emit((e.target as HTMLElement).id);
  }

  ngOnInit(): void {
  }

}
