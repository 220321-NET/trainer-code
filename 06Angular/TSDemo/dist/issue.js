export class issue {
    constructor(id, title, score, content, answers, dateCreated) {
        this.Id = id;
        this.Title = title;
        this.Score = score;
        this.Content = content;
        this.Answers = answers;
        this.DateCreated = dateCreated;
    }
    toString() {
        return `Id: ${this.Id} Score: ${this.Score} Title: ${this.Title} Content: ${this.Content}`;
    }
}
