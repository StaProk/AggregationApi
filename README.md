#API aggregation

End-points:
- aggregation end-point
url: http://localhost5050/api/aggregation/aggregate?hashtag={hashtag}&userIdentifier={userIdentifier}&keyword={keyword}&latitude={latitude}&longitude={longitude}&q={q}&sources={sources}&from={from}&sortBy={sortBy}

method: GET

description: it has all the fuctions of news, weather and twitter endpoints with all the parameters

output: a JSON object with a list of articles, a list of weather reports and a list of tweets 

possible errors and exceptions:
all the error messages and exceptions as all the other end-points (because it calls the same services and in the try catch it has the same exceptions)



- news end-point 
url: http://localhost5050/api/news?q={q}&sources={sources}&from={from}&sortBy={sortBy}

method: GET

description: it takes 1 to 4 parameters and returns a list of articles with those parameters true

parameters: q (meaninig keyword, optional), sources (required), from (optional, with default: today's date), sortby (optional, with default: publicedAt meaning from newer to olderl)

output: a JSON object with a list of articles

possible errors and exceptions: if we don't pass a value for sources we get a bad request that pinpoints that and if we return too much articles or in general we give a bad request to the external api from the parameters we get a StatusCode 500 message that explains it

requirements: none (the apikey is stored in appsettings.json)



- weather end-point
url: http://localhost5050/api/weather?latitude={latitude}&longitude={longitude}

method: GET

description: it takes a location by the 2 parameters and returns a list of weatherforecast reports for the next 5 days for every 3 hours

parameters: latitude (required), longitude (required)

output: a JSON object with a list of weather reports

possible errors and exceptions: if we don't pass a value for latitude and/or for longitude we get a bad request that pinpoints that and if we get any status error from the external api we get a StatusCode 500 message that explains it

requirements: none (the apikey is stored in appsettings.json)



- twitter end-point
url: http://localhost5050/api/tweets/search?hashtag={hashtag}&userIdentifier={userIdentifier}&keyword={keyword}

method: GET

description: it takes 4 parameters searches for the tweets that has those parameters true and returns them

parameters: hashtag (required), userIdentifier (required), keyword (required)

output: a JSON object with a list of tweets

possible errors and exceptions: if we don't pass a value for hashtag, for userIdentifier and/or for keyword we get a bad request that pinpoints that and if we get any status error from the external api we get a StatusCode 500 message that explains it 

requirements: when running on local machine it needs a bearer token from an X application and that application to connect to the project. Also, that application must have proper level of access (meaning to have the pro or basic package, both of them are not free) an app as such can be created inside an X project inside the X developer portal(it requires registration).



In order to add a new API, in the aggregation controller the service of the new API has to be called, same as the other API services. Also, for the new API a controller, a service and the required models have to be created or inherited by a library of the external api.

In order to add more APIs or change the aggregation API in a local machine .NET SDK 6.0 or higher and Visual Studio or any IDE that supports .NET are needed. Swagger has been added so the API can be manually tested on Google Chrome (or any other browser). The code can be found and cloned in the github repository url:

The the API runs on `https://localhost:5050`.