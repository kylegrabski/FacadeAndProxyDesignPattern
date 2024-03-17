# Facade and Proxy Design Pattern Implementation

This is ment to gain a better understand of design patterns, specifically the Facade and Proxy patterns.

### FACADE
The Facade design pattern is meant to provide a simple interface for complex subsystems.  
It abstracts calls to complex logic, such as calling multiple functions or instantiating classes.  
This pattern is good for layering subsystems.  
If there are many dependencies, a facade is perfect to abstract and decouple everything.
The facade pattern is *typically* a Singleton.

### PROXY
The Proxy design pattern works as an intermediary between objects or connections by controlling access to an object.  
There are multiple types of proxies:
- #### Remote Proxy
- - Controls access to a remote object (one that belongs to a different address space).
- #### Virtual Proxy - ***LETS LOOK INTO USING THIS FOR THIS PROJECT***
- - Used in lazy initialization. Defers the work instead of in the constructor, meaning it will only load or run logic that is needed until its needed.
- #### Protection Proxy - ***THIS IS WHAT WE WILL BE USING IN THIS PROJECT***
- - Contains logic to determine authorization of specific logic. 

## WHAT THIS PROJECT WILL DO
- -  [ ] This will hit an external api ([such as JSON Placeholder](https://jsonplaceholder.typicode.com/)) to get a list of users.  
- - [ ] We will use a proxy in between the request to the JSON API and our response to the requester. 
- - - [ ] It will check if the requester is an admin, if so it will give more data about the list of users such as the users posts.    
- - [ ] We will use a Facade Service to construct the payload call to the proxy (which calls the gateway) and also call our repository that will look up our database (which just for this project will be a JSON file since this project isn't about database connections) of users to check if the requester is an admin.  
- - [ ] Unit tests to make sure the Facade and Proxy patterns are being used correctly. This project will create multiple object types to help with this.