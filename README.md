# MeetupAPI
## Launching the application

You need to install the following programs:

- MSSQL
- Visual Studio
- .NET 6

Download this repository or install git and clone it using the command "git clone"

Everything is ready to start

To start the program, open Meetup.sln and click F5
## Authorization

1. You need to register using the method Register. Fill in all the required fields
2. Log in using the method Login.

## Project architecture (n-layer)
![image5-2](https://user-images.githubusercontent.com/78380344/199097062-b55376b9-23df-4ad8-835c-06113df79297.png)

These layers are frequently abbreviated as UI, BLL (Business Logic Layer), and DAL (Data Access Layer). Using this architecture, users make requests through the UI layer, which interacts only with the BLL. The BLL, in turn, can call the DAL for data access requests. The UI layer shouldn't make any requests to the DAL directly, nor should it interact with persistence directly through other means. Likewise, the BLL should only interact with persistence by going through the DAL. In this way, each layer has its own well-known responsibility.

One disadvantage of this traditional layering approach is that compile-time dependencies run from the top to the bottom. That is, the UI layer depends on the BLL, which depends on the DAL. This means that the BLL, which usually holds the most important logic in the application, is dependent on data access implementation details (and often on the existence of a database). Testing business logic in such an architecture is often difficult, requiring a test database. The dependency inversion principle can be used to address this issue, as you'll see in the next section.

## Using technologies
 - **Entity framework** 
 Entity Framework is an object-relational mapper. This means that it can return the data in your database as an object (e.g.: a Person object with the properties Id, Name, etc.) or a collection of objects
 - **Jwt token**
Tokens are used to transfer authentication data in client-server applications. Tokens are created by the server, signed with a secret key and transmitted to the client, who then uses this token to confirm his identity.
 - **AutoMapper**
AutoMapper is used to map one object to another . Mapping works by converting an input object of one type into an output object of another type.
 - **FluentValidation**
Fluentvalidator using to validate models
 - **Swagger**
Swagger allows computers and users to better understand the capabilities of the REST API without direct access to the source code.
 - **Moq**
 The Moq is designed to simulate objects.
 - **Xunit**
 This is a testing environment that provides a set of attributes and methods that we can use to write a test
