var sayHi = function() {
    alert('haii...')
    greet()
}

let sayHello = () => {
    alert('herrrow?')
}

let ohNoYouCant = (e) => {
    e.stopPropagation()
    let response = confirm('how dare you look at other cats')

    if(!"") {
        console.log('i knew i could trust you')
    }
}

let phew = function() {
    console.log('i knew i could trust you')
}

let object = {
    1: 2,
    2: 3,
    3: 4
};

function greet() {

    
    greet2()
    
    // function declaration
    function greet2() {
        console.log(foo);
        alert('hello world!')
        if(true) {
            let cat;
            console.log(cat)
            var foo = 'bar'
            cat = 'auryn'
            const fu = 'bar'
        }
        // console.log(fu) //reference error
        // console.log(cat) //reference error
        // console.log(foo) //works
    }

}
