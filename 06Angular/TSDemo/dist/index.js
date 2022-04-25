"use strict";
class issue {
    constructor(id, title, score, content) {
        this.id = id;
        this.title = title;
        this.score = score;
        this.content = content;
    }
    toString() {
        return `Id: ${this.id} Score: ${this.score} Title: ${this.title} Content: ${this.content}`;
    }
}

let testIssue = new issue(1, 'test', 0, 'test content');
console.log(testIssue.toString());
