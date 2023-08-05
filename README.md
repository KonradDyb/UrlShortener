# UrlShortener

UrlShortener is amazing application thanks to which you will get rid of copying long links in different applications.
It follows KISS rule to keep it simple stupid. You just paste URL then click button 'Shorten' and voila.
You received shortened link :) This is the way ! 
## How to start?
- Download and install the newest .NET Sdk from this page https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Download and install SQL Server 2022 https://info.microsoft.com/ww-landing-sql-server-2022.html?culture=en-us&country=us
- Download and install SSMS or any other tool to maintain database https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
- Download and run project in IDE e.g. Visual Studio 2022 Community Version https://visualstudio.microsoft.com/vs/ or paid option Jetbrains Rider https://www.jetbrains.com/rider/download/#section=windows
- Run in your IDE terminal, command line or Powershell command to download and install the newest Entity Framework 'dotnet tool install --global dotnet-ef'
- Use 'dotnet ef database update' command from 'UrlShortener.WebApplication' scope to create database.
![image](https://user-images.githubusercontent.com/54625765/225138194-7e14fee1-0abf-4b67-a06b-2f65cd198863.png)
- Run and use application :)
- If there are any issues please create that in github / contact the author !
## Key assumptions 
- MSSQL database can handle a large number of records. 
- Tech stack should support the need of my service and fast response times.
- User interface should be intuitive and user-friendly.
- Use SeriLog library to provide logs. I will use sink for the MSSQL Server.
- Create CI pipeline to check for any errors before merging PR.
## Future Ideas
- Definitely create better looking UI. 
- User authentication/authorization and store shortenUrls per user.
- Maybe provide temporary shortUrls. The logic can be handled through background service and delete after specific period of time.
- If logic will be extended then use CQRS and MediatR for command/queries.
- We can host it in Cloud to make application  more scalable, elastic, fault tolerance and secure e.g Azure Cloud.
- If someone will create more features than automatically should add more tests for that.
- Extend CI/CD pipeline.
- Use Seq for quickly browsing logs.
- I also like to have seperated 'Application' and 'Domain' layer.

## Task Description 
>Build a URL shortening service like TinyURL. This service will provide short aliases redirecting to long URLs.
### Why do we use Url shortening?
URL shortening is used to create shorter aliases for long URLs. We call these shortened aliases “short links.” Users are redirected to the original URL when they hit these short links. Short links save a lot of space when displayed, printed, messaged, or tweeted. Additionally, users are less likely to mistype shorter URLs.

For example, if we shorten the following URL: `https://www.some-website.io/realy/long-url-with-some-random-string/m2ygV4E81AR`

We would get something like this: `https://short.url/xer23`

URL shortening is used to optimize links across devices, track individual links to analyze audience, measure ad campaigns’ performance, or hide affiliated original URLs.

### URL shortening application should have:
 - A page where a new URL can be entered and a shortened link is generated. You can use Home page.
 - A page that will show a list of all the shortened URL’s.
### Functional Requirements:
- Given a URL, our service should generate a shorter and unique alias of it. This is called a short link. This link should be short enough to be easily copied and pasted into applications.
- When users access a short link, our service should redirect them to the original link.
- Application should store logs information about requests.
### Non-Functional Requirements:
- URL redirection should happen in real-time with minimal latency.
- Please add small project description to Readme.md file.

