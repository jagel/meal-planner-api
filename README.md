# Meal planner API

Meal planner back end


# Projects

### JGL.Infra.Globals.API (Globals definitions)

Global definition required to create new projects.

- JGL.Infra.Globals.API.Responses
    - JGLModelResponse (Model response to public API)

### JGL.Infra.ErrorManager (Handle errors)

Manage error handler 
- JGL.Infra.ErrorManager.Data.Responses
    - ErrorResponse: Model to manage response
    - ErrorItem: Model to manage each error definition

- JGL.Infra.ErrorManager.Domain:
    - Model requests
    - Error definitions

### JGL.Infra.ErrorManager.Data.Definitions
EMessageType
- Transaction: Error response when was not able to request data among microservices
- Validation: Error response for internal validation in services 
- Database: Error in database items
- Internal: Error response not controlled

ApiCodesResponse
 - Success = 200
 