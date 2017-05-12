# AspNetCore MasterClass
## with Dino Esposito, Iasi 2017

## Arhitecture

###Kestrel 
		- is not designed to be exposed to the public
		- embedded web server

1. The pipeline is simplified, modules can be added, you don't have to remove modules to make a lighter pipeline
2. The request is handled 

The **middleware** acts like a module
   begin request - middleware - your code - middleware - end request

### IIS
IIS - reverse proxy passes the request to the embedded server

Suggestion - create a content folder in the *wwwroot*

Program.cs - is the application

try/catch - handle the errors in one single place (global.asax)
avoid session - session disappears, lost of data

UseStartup
	- you can use ConfigureWhateverEnvironment 

Owin is dead
	- as also katana

## Middleware
[libuv](https://github.com/libuv/libuv) - multi-platform library for async I/O

IIS - acts like a reverse proxy (a forward proxy in caching scenario)

**UseUrls** - configure the location of the kestrel server

**StaticFiles** - the authorization is resolved at the controller level ??(is this accurate?)

### Use (more like modules)
MVC
app.Run
> If MVC is not involved, then the next registered app.Run will handle the request.
> Application with roles at the controller label

### Map - more like handlers
app.MapWhen

### Sallient point - be a good citizen, write the headers before the body; write the body as last as possible

Scoping Services
services can be injected in the Invoke method

### Built-in middlewares
Authentication, CORS, rewriting etc

## Controllers

## Entity Framework

POCO are overrated (check if this is a biased opinion)


##  Global Data

## Switch to core issues
	- authentication
	- import core packages
	- change the configuration (JSON)
	
## Good features
@inject in Views

## Tag Helpers

new feature

## Entity Framework missing features

######## the code in this demo might not compile is not maintained