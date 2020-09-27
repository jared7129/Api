# Api

### Getting started...  
Each api implementation consists of a request and a response, as well as a generic facade operation to execute the request and return the response. The request has properties reflecting the parameters supported, and the response represents the object model for the returned json.  

The example below, simply populates a request, invokes the facade operation, and recieves the response in return.  
```csharp
TRequest request = new TRequest();
TResponse response = await {Api}.{Action}.QueryAsync<TRequest, TResponse>(request);
```

A few other noteworthy members.
##### Request
```csharp
var uri = request.GetUri(); // Gets the full request uri, including query parameters.
var params = request.GetQUeryStringParameters(); // Gets a list of all the added parameters.
```
##### Response
```csharp
response.RawJson // The raw json returned by Google.
response.RawQueryString // The querystring sent to Google when invoking the request.
```

*** 

### Supported Operations for the API: 
  * Place Search
    * Find
    * Near By
    * Text
  * Place Details
  * Place Photos
  * Place Autocomplete
  * Query Autocomplete

### Tests
The following are needed to run tests:

The test project stores settings related to your Google subscription in `application.default.json`. More importantly, the ```ApiKey```, used to identify the Google subscription.  
```json
{ 
  "ApiKey": "",
  "CryptoKey": "",
  "ClientId": "",
  "SearchEngineId": "",
}
```
You can generate a key, by following the following link: https://console.developers.google.com/  

*** 
