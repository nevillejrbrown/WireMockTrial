# WireMock.net Deployment Example

This provides one example of how a WireMock service can be packaged for deployment.

> For many testing needs WireMock can be used __inline__ directly from your test code, which is even more convenient than using a deployed instance. Whether you use a deployed app, a standalone instance running locally, or start an instance of wiremock directly from your code is a matter of choosing the best design for the purpose at hand. 

See https://github.com/WireMock-Net/WireMock.Net/wiki for an outline of the different use cases (unit tesing, standalone and deployed).

## Start up

Running `dotnet run` from TemplateForWiremock\WireMockTemplate will start the web application. Deployment to an azure app service can also be done in the usual way.

## Using this app you will get:
- A web application hosting a WireMock instance with configurable responses as defined by the json files in the `__admin\mappings` folder in the repo
- Automatic recording of requests received by the mock. Records of requests can be accessed from the `http://localhost:5161/__admin/requests` endpoint
- A starting point for using more advanced features of WireMock.

## Other considerations
- When hosting as a web application in Azure, consider attaching a blob storage container or similar to a web applicaiton at the path `__admin\mappings` where the mappings are held, so that mock behavior can be changed in-flight by just modifying the mapping files.
- There is a library available for remotely controlling deployed WireMock instances from .net projects: https://www.nuget.org/packages/WireMock.Net.RestClient

## Example mappings

- The example mappings in this template are set so that:
    - At the endpoint `/my_stub_endpoint`, POST requests not matching other rules should be given a 200 OK response. 
    - To demonstrate request matching, If the POST request to `/my_stub_mapping` contained an XML body:
        `<PRODUCTNAME>000XX5</PRODUCTNAME>` with `XX5` in `<PRODUCTNAME>`, the server is set to return a 500 Server Error.  With `XX0` in the product name, the server is set to delay a 200 OK response by 10 seconds.
