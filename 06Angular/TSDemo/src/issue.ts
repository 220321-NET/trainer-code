import { answer } from './answer'

export class issue {
    constructor(id: number, title: string, score: number, content: string, answers: answer[], dateCreated : string | Date)
    {
        this.Id = id;
        this.Title = title;
        this.Score = score;
        this.Content = content;
        this.Answers = answers
        this.DateCreated = dateCreated
    }
    public Id : number
    public Title : string
    public Score : number
    public Content : string
    public Answers : answer[]
    public DateCreated : string | Date
    public toString() {
        return `Id: ${this.Id} Score: ${this.Score} Title: ${this.Title} Content: ${this.Content}`
    }

}