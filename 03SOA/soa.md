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

# REST - REpresentational State Transfer
"RESTful API"
Rest is a one of the ways we can create web services.

## REST Principles
### Client-Server
### Uniform Interface
### Stateless
client's state
### Cacheable
your resource
### Layered System

## Richardson Maturity Model
This is a 4 level model, that shows how REST compliant, or how RESTful your service is.
### Level 0
One Verb (usually POST), One end point
### Level 1
One Verb, multiple end points for different resources
### Level 2
Multiple Endpoints for different resources and Multiple Verb (GET, PUT, POST, DELETE, etc) - this is where we commonly stop
### Level 3
Level 2 + HATEOAS

## HATEOAS - Hypermedia as the engine of application state
