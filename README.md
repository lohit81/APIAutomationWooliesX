# APIAutomationWooliesX

# REST API using RESTSHARP

# Introduction
RestSharp is one of the several ways to create a web service or web request in .NET. Here, we’ll take a look at RestSharp specifically, its features and benefits, and a few examples of RestSharp in action.

RestSharp is a comprehensive, open-source HTTP client library that works with all kinds of DotNet technologies.  It can be used to build robust applications by making it easy to interface with public APIs and quickly access data without the complexity of dealing with raw HTTP requests. RestSharp combines advantages and time-saving features with a simple, clean interface, making it one of the hottest REST tools.
With its simple API and powerful library, REST architecture is the tool of choice for programmers looking to build detailed programs and applications. RESTful architecture provides an information-driven, resource-oriented approach to creating Web applications. It also offers common tasks such as URI generation, payload parsing etc.

# Requirement 
-	Visual Studio IDE (I am using VS 2019)
-	Create a NUnit project.
-	Add packages via NuGet Package Manager like RestSharp, NUnit, SpecFlow, SpecRun.SpecFlow.

# Structure
 
 
 [
![APIStructure](https://user-images.githubusercontent.com/4488811/104838762-1ebdbf80-5911-11eb-9089-666e39f9d913.png)
](url)
 
# Implementation
As per above structure, we have different folders in place such as 

# Feature
In this test project, the feature folder has a feature file which holds scenarios for verbs like “GET”, “POST” and “PUT”. Get scenario/method is basically fetches the data from the server over the REST REQUEST. POST scenario is to add items over resource and PUT is to alter existing Json item(s).
I have created separate scenarios for GET, POST and PUT using Gherkin language. I defined repetitive steps in background keyword to avoid redefining them. Also used Scenario outline to pass test data as parameters defined in the Example data set.

# Steps
This folder class is nothing but Binding of the step definitions of feature class(es).

# Helper
In this folder, I’ve APIHelper class pertaining methods such as RESTClient, RESTRequest, RESTResponse for Creating a URI with endpoints, then operation to be performed and then verify the outcome of the API as response respectively.

# Model
This folder has class pertaining properties for Json resources by which we need to add values to the server during POST operations. 

      We can have multiple class files based on the POST or PUT methods to perform.

# Build and Execute

It is very important to build your solution without any anomalies. Once successfully build, Select TestTest Explorer. It contains all the Test scenarios you listed. If you wish debug code, just choose run as Debug mode upon right clicking of the scenario. Else you can run all scenarios by pressing PLAY icon.

Note that since I am using freeware of SpecFlow, there’s an additional delay to invoke scenarios.

Another way to execute all scenario is via developer command prompt. This project solution has file named as “runtest.cmd”, it’s a powershell script file, first builds the project and then runs the SpecRun from the bin folder of the project. This complete UI-less approach to execute scenarios.

# Improvement
As this solution is just for test exam only, of course this project solution has few improvements such as reduce number of methods such as POST and PUT, as PUT verb alters the item in Json and if resource is not available we can add new resource to the Json data where POST only adds new resource to the server. 
IRestResponse methods can be handled in a way to reduce the repetitive code of lines.

For larger number of data, we can use excel or csv but need to include SpecRun + Excel package then in the Example section of Scenario Outline, just add tag as @source: datafilename.xls and in Example section just provide the parameter names matches to the excel file.

If there are more endpoint then its good to have another folder say “Pages” and can manage classes in it and also as mentioned above we can manage POST properties in Model folder too. 

