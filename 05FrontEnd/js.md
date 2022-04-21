# Javascript
Javascript to Java is like Hamster to Ham

Javascript is a scripting language used to provide behaviors to websites, which means it's a language that web browsers know how to interpret.

### Ways to include js
- Script tag in html
- script tag with src that points to an external js file

### Typing
Javascript is a dynamically typed, or loosely typed language, which means we don't explicitly state what type the variable is. Instead we use `var` or `let` keyword to denote that it is a variable.

#### Scopes
- global/window scope
- function scope
- block scope

#### Let vs Var vs Const
let is block scoped but var is not, which means the tighest scope for var is function scope. Tldr; just use `let`.
`const` is for values that do not change

#### Data Types in JS
 - SONBUNS 
 - Symbol
 - Undefined
 - Null
 - Boolean
 - Object
 - Number
 - String

#### Truthy and Falsey values
Falsey values are: 0, false, "", undefined, NaN, Null
Everything else is truthy

### Events
We can subscribe to various browser events such as mouseenter, mouseleave, click, and  more... we can attach a function to apply behaviors that reacts to those events.

### Hoisting
certain things, such as var or functions using function declaration, are hoisted to top of its scope (function scope, global, etc), and are available before the program reaches its declaration line.
Tldr; use `let` and be a reasonable human being and declare things before you refer to them

### This