# Azure Functions Mediator Example

## HttpExample

Example taken from the basic walkthrough from Microsofts documentation here https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio

`GET http://localhost:7071/api/HttpExample`

## MediatR

Example taken from https://github.com/alexjamesbrown/Mediatr.AzureFunctions which utilises Mediatr and Fluent Validation.

`GET http://localhost:7071/api/AddPackageFunction`

```json
{
    "ExId": "123"
    "Title": "MyTitle",
    "Description": "MyDescription"
}
```
