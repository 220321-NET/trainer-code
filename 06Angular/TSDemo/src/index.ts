class issue {
    constructor(id: number, title: string, score: number, content: string)
    {
        this.id = id;
        this.title = title;
        this.score = score;
        this.content = content;
    }
    public id : number
    public title : string
    public score : number
    public content : string
    public toString() {
        return `Id: ${this.id} Score: ${this.score} Title: ${this.title} Content: ${this.content}`
    }
}

let testIssue = new issue(1, 'test', 0, 'test content');

console.log(testIssue.toString())