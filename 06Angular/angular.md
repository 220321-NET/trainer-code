# Angular

## What is SPA
In Web 1.0, each GET request to a url was responded with an HTML document.
However, as the frontend matured and we started expecting more out of html/css/js, we began to think about way to render html pages dynamically without having to refresh. Single Page Application _Loads_ all its assets (aka html/css/js files + anything else it needs to function minus the data) in the first GET request, and afterward there is no page refresh. The URL changes you see is simulated. When users navigate to different pages, different parts of the html document is dynamically swapped out.

Tools such as Angular, React, Vue helps developers create Single Page Applications.

### Advantages of SPA
- Modularity (promoting code reusability, scoping, and providing single source of truth)
- faster load times after the initial load
- Easier to non-programmers to work with (less daunting since everything is done in small bite sized chunks)
- break separation of concerns between html css and js content presentation behavior

### Disadvantages of SPA
- initial load takes longer than server side rendering
- learning curve with tools

## What is Angular
Angular is a Frontend SPA platform/framework. It provides structure and tools to easily develop single page applications.

### Framework vs Library 
Framework are usually more opinionated on how it wants to function, where as libraries are more or less a collection of tools. Frameworks are heavier, and provides more all-in-one support (ex. Angular, ASP.NET). Libraries are lighter in size and provides you with a certain set of functionality (ex. React, Serilog)

## To Set up Angular
First, install angular globally by using `npm install -g @angular/cli`
Then spin a new angular application by running `ng new <app-name>`
In order to spin up the application, run `ng serve`
To generate different angular elements, run `ng generate <type> <name>`

## Moving parts of Angular
### Component
Component is a reusable bundle of html/css/ts. Components handle presentation logic.
When you generate component using `ng generate component <component-name>` it comes with html, css, ts, and ts testing file.

### Decorator
Decorator is a special syntax that lets angular know that it is angular's element. usually they start with `@` symbol, followed by the name, such as `@Component`, `@Directive`, `@NgModule`, `@Injectable`, `@Pipe` and more. After that syntax, comes configuration object.

### Modules
Angular module is very similar to namespaces in C#. Like how we bundle or register different types to a namespace, we register different angular elements to a module. All components have to be declared in ONE module, and in order for other modules to have access to components declared in different modules, first, you need to export that component in your module, and then you need to import that particular module in module.ts file.
Modules are decorated with `@ngModule` decorator that contains information regarding its members (components in declarations property), its dependencies (imports property) and what it exports, and so on and so forth.

### Services
Services are used to encapsulate any non-presentation logic. Services are also very useful to send data between two components that are not related in parent-child relationships

### Dependency Injection
In any angular elements, we can ask for other classes/types/interfaces it require to function by listing them inside its constructor parameter.

### Lifecycle hooks
In each angular component's life time (from initial render to destruction), there are many different events or stages it goes through. As developers, we can subscribe to those events using lifecycle hooks to do something whenever those events are triggered. For example, if you want to do some DOM manipulation once the component renders, you can put that logic in ngOnInit function, or if you want to clean up some resources when angular destroys the component, do so on ngOnDestroy. ngDoCheck is particularly useful if you're relying heavily on an external library that angular is not aware of. 