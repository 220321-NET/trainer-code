# Typescript

## Nodejs
Node.js is a serverside interpreter/environment for javascript. NodeJS also comes with NPM, Node Package Manager, which is similar to Nuget in C#

## NPM
Node Package Manager. We use NPM to manage our dependencies for js projects, as well as write scripts that we can run by doing `npm <name>`
In order to install packages from NPM, we use `npm install` or `npm i` command followed by the package name. For example `npm install typescript`.
When we install packages, they go in the special folder named node_modules.
You can use --global to install the package accessible everywhere in your machine, or you can use --save to save the package as your project dependency. --save-dev saves the package information as your dev dependency. 

## TypeScript
In order to run locally installed typescript, first install the package and then run `npx tsc` ("typescript compiler")

Typescript is a superset of javascript, or as people like to say, if you make OOP developers code in javascript, they'll come up with typescript.

Typescript is a strongly typed language, which means that it will enforce you to define types as you define variables. Instead of doing `let foo = 'bar'`, we have to define the type, by doing `let foo:string = 'bar'`

Typescript is not natively understood by browsers, so we have to transpile it down to javascript. Do it by `npx tsc <file-path>`. If you don't want to run this everytime you change, you can use `npx tsc --watch <file-path>`

Typescript enforces type safety by having you declare types for your variables. But it is still javascript under the hood.

## Additional Typescript Features
### Additional Types
TS introduces types that doesn't exist in javascript, such as any, void, never, and more!
- Any type is when you want to use ts like js, really any data type can be assigned to the variable.
- void is exclusively used for fn's. Just means function does not return anything.