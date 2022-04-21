function apiUrl() {
    let apiKey = '633db2f9-8706-4329-bcb4-352e765361b4'
    let apiUrl = 'https://api.thecatapi.com/v1/images/search'

    return apiUrl + '?api_key=' + apiKey
}

// XMLHttpRequest (older way)
// First, we open the connection and assemble the request
// Second, we send the request
// Third, we wait for the response to arrive
// Fourth, we parse the response

/** 5 XMLHTTPRequest Ready States
 * 0: Uninitialized
 * 1: Loading (We have successfully connected with the server and we sent the request)
 * 2: Loaded (server has received the request and has called the send method)
 * 3: Interactive (we are in the middle of receiving/processing the response)
 * 4: complete (the response has been received)
 */

function getRandomCat() {
    console.log('getting a random cat...')
    let xmlRequest = new XMLHttpRequest()

    //open the connection to server with the particular url we want
    xmlRequest.open('GET', apiUrl());

    //and we'll send the request
    xmlRequest.send();

    xmlRequest.onreadystatechange = function(e) {
        // == vs === : triple equals checks for the type equality as well as the value equality - does not type coerce
        if(this.readyState === 4 && this.status === 200) {
            let response = JSON.parse(this.responseText);
            // breeds: [], height: number, id: string, url: string, width: number
            let cat = response[0];
            let catimg = document.getElementById('cat-img');
            catimg.setAttribute('src', cat.url);
        }
        // console.log('ready state changed', xmlRequest, e);

    }
}

//IFFY: immediately invoked function expression 
document.onload = (() => {
    // let btn = document.querySelector('#cat-container > button')
    // btn.addEventListener('click', getRandomCat);
    let catContainer = document.querySelector('#cat-container')
    let btnElem = document.createElement('button')
    btnElem.setAttribute('class', 'btn btn-info')
    btnElem.addEventListener('click', getRandomCat)
    
    let btnText = document.createTextNode('get me another cat!')
    btnElem.appendChild(btnText)
    
    catContainer.append(btnElem)
    getRandomCat();
})()

// Fetch API (newer way)