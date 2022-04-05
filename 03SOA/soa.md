# Service Oriented Architecture

## What is a Web Service?
Any piece of software that serves other programs/software
usually over the web... usually through http...

## Why do we build Service Oriented Architecture?

## What is Service Oriented Architecture?
Type of architecture style that revolves around services
Basically, we decouple the presentation logic from business logic/data access logic

## Monolithic Architecture?
Monolithic architecture is an architectural style, where everything is tightly bundled together.
For example, in our P0, our presentation logic was directly calling the BL/DL methods and they were all packaged in the same sln. If we were to deploy this on the web or send this to our friend, we package the whole thing up. This tight coupling makes the application's data and business logic available only to the UI.
But... what if we want more money? What if our store takes off, and everybody wants to use our data to get more traffic to their websites? What if we want to serve more than just our presentation layer?

## SOA Design Principles
 
### Standardized Service Contract
### Loose Coupling
### Service Abstraction
### Service Composability
### Service Interoperability

### Service Reusability
### Service Autonomy
### Service Stateless
### Service Discoverability

(SOA Principles)[https://www.guru99.com/soa-principles.html]