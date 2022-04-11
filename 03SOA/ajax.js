function getMeACat()
{
    let xml = new XMLHttpRequest()

    /*
    * ReadyStates
    * 0: uninitialized
    * 1: loading (we successfully connected with the server), and we have opened the connection
    * 2: loaded (server received the request) and the send method has been called
    * 3: interactive (we're in the middle of processing the request), receiving the response body
    * 4: complete (we got the response)
    */

    //assembling our http request
    xml.open("GET", "https://cataas.com/cat?json=true", true); //This gets us to readystate 1

    xml.send(); //sending the request, this is now at 2

    xml.onreadystatechange = function() {
        if(this.readyState === 4 && this.status === 200)
        {
            let catPicUrl = "https://cataas.com/cat/";
            let response = JSON.parse(this.response);

            let catImg = document.getElementById('cat-img')

            catImg.setAttribute('src', catPicUrl + response.id)

            let catId = document.querySelector('#cat-id')
            let catTags = document.querySelector('#cat-tags')
            catId.innerHTML = response.id;
            catTags.innerHTML = response.tags
            console.log(catId);
        }
    }
}

function getMeADog() {
    let dogUrl = 'https://dog.ceo/api/breeds/image/random';

    fetch(dogUrl).then((res) => {
        return res.json()
    }).then((resJson) => {
        console.log(resJson)
        let dogImg = document.getElementById('dog-img')

        dogImg.setAttribute('src', resJson.message)

        let dogUrl = document.querySelector('#dog-url')
        dogUrl.innerHTML = resJson.message
    })
}

document.onload = getMeADog()