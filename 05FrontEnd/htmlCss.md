# HTML & CSS

## HTML
- Hypertext Markup Language
- HTML documents are comprised of tags

### Tags
- Tags are the fundamental unit of html pages
- Different types, such as html, body, head, header, diff headings, ul, li, etc. 
- Most have opening and closing tags with the content in between

### Attributes
Attributes describe additional properties to tags. Global attributes are available to all tags/elements. 

#### Class vs Id
- Class
    - is to select multiple elements that share a functionality or a purpose
    - an element can have multiple classes
    - `<div class="container my-container anotherclass"></div>`
- Id
    - we use id's to uniquely identify an element

#### Alt attribute
alternate attribute is for display alternate text incase the object doesn't load.

### Semantic Tags
Semantic tags are tags that describe the role of the element in the webpage, such as, header, nav, article, etc.

### DOM: Document Object Model
It is a tree structure, that represents the structure of the web page, that js and css can use to interact with the webpage

## CSS
Cascading Style Sheet

### Selectors
- Class Selector: .class-name
- id selector: #id-name
- tag selector: body
- pseudo-class: 
    - Ex. a:hover
    - we can style certain elements based off the events or state of the event such as hover, visited, focus..etc.
- pseudo-element:
    - Ex. p::first-line
    - with pseudo element we can style a portion of an element (like the first letter or first line or before or after the element)
- CSS combinator selectors
    - children selector 
        - `div > p`

### Colors
- just using color name
- hex numbers
- rgb
- rgba

### Different ways to include css styles
- inline
- internal
- **external**: preferred way
- watch out for the order you include them

### [Bootstrap](https://getbootstrap.com)
is a front-end tool kit, that supports mobile first, responsive web design through grid layouts and other easy to use html/css components. 

### Responsive Web Design
It's a design that responds to different layout sizes, or in fancy terms, viewports.

### CSS Box Model
Every element has 4 parts to the space it takes up in webpage. 
- Content
- Padding
- Border
- Margin