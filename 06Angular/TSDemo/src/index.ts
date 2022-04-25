import { issue } from './issue'
import { answer } from './answer'

export function submitIssue(event : Event) : void {
    //I want to grab all data from html forms,
    //and make a post request to the /api/issues end point
    event.preventDefault()
    console.log('submitting a new question..')

    let form = document.getElementById('new-question-form') as HTMLFormElement;
    let title = document.getElementById('q-title') as HTMLInputElement;
    let content = document.getElementById('q-content') as HTMLTextAreaElement;

    let newQuestion : Partial<issue> = {
        Title: title.value,
        Content: content.value,
        DateCreated: new Date(),
        Score: 0
    }

    console.log(newQuestion);
    
    fetch('https://stackliteapi.azurewebsites.net/api/Issues', {
        method: 'POST',
        headers: {
            'content-type': 'application/json; charset=utf-8'
        },
        body: JSON.stringify(newQuestion)
    }).then(res => res.json()).then(resBody => {
        console.log(resBody)
        alert('question added successfully!')
        title.value = '';
        content.value = '';
        window.location.pathname = ('06Angular/TSDemo/index.html')
    })
}

export function populateQuestionTable() : void {
    fetch('https://stackliteapi.azurewebsites.net/api/Issues', {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    }).then((res) => res.json()).then(resbody => {
        console.log(resbody)
        let table : HTMLTableElement = document.getElementById('sl-table') as HTMLTableElement;
    
        let tbody : HTMLTableSectionElement = table.getElementsByTagName('tbody')[0];
    
        resbody.forEach((element : issue) => {
            
            let tableRow : HTMLTableRowElement = tbody.insertRow(0);
            tableRow.insertCell(0).innerHTML = element.Id.toString();
            tableRow.insertCell(1).innerHTML = element.Title;
            tableRow.insertCell(2).innerHTML = element.DateCreated.toString();
            tableRow.insertCell(3).innerHTML = element.Score.toString();
        });
    })

    // let questionArr : issue[] = [
    //     {
    //         id: 1,
    //         title: 'title',
    //         score: 0,
    //         content: 'content',
    //         answers: [],
    //         dateCreated: 'today'
    //     },
    //     {
    //         id: 2,
    //         title: 'title',
    //         score: 0,
    //         content: 'content',
    //         answers: [],
    //         dateCreated: 'yesterday'
    //     }
    // ]


}
