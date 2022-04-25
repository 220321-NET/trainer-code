import { issue } from './issue'
import { answer } from './answer'

export function submitIssue(event : Event) : void {
    //I want to grab all data from html form,
    //and make a post request to the /api/issues end point
    event.preventDefault()
    console.log('submitting a new question..')

    /**
     * grabbing form element by its id
     * and type casting to table element to gain access to table related methods
     */
    let form = document.getElementById('new-question-form') as HTMLFormElement;
    let title = document.getElementById('q-title') as HTMLInputElement;
    let content = document.getElementById('q-content') as HTMLTextAreaElement;

    //Utility class to declare that i'm only using part of this class
    let newQuestion : Partial<issue> = {
        Title: title.value,
        Content: content.value,
        DateCreated: new Date(),
        Score: 0
    }
    
    //sending POST call to our api to create new question
    fetch('https://stackliteapi.azurewebsites.net/api/Issues', {
        method: 'POST',
        headers: {
            'content-type': 'application/json; charset=utf-8'
        },
        body: JSON.stringify(newQuestion)
    }).then(res => res.json()).then(resBody => {
        alert('question added successfully!')
        
        //Reset the form
        title.value = '';
        content.value = '';

        //navigate to "home page"
        window.location.pathname = ('06Angular/TSDemo/index.html')
    })
}


/**
 * dynamically populating table from the data we get from be
 */
export function populateQuestionTable() : void {
    //sending GET request
    fetch('https://stackliteapi.azurewebsites.net/api/Issues', {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    }).then((res) => res.json()).then(resbody => {
        // accessing the table element to populate with data
        let table : HTMLTableElement = document.getElementById('sl-table') as HTMLTableElement;
    
        //get the table body
        let tbody : HTMLTableSectionElement = table.getElementsByTagName('tbody')[0];
    
        //For each element in the response (aka issue objects)
        //insert a new row
        resbody.forEach((element : issue) => {
            
            let tableRow : HTMLTableRowElement = tbody.insertRow(0);
            tableRow.insertCell(0).innerHTML = element.Id.toString();
            tableRow.insertCell(1).innerHTML = element.Title;
            tableRow.insertCell(2).innerHTML = element.DateCreated.toString();
            tableRow.insertCell(3).innerHTML = element.Score.toString();
        });
    })
}
