# Demo-Application-Structure

## Features
 1.  Component-ization
     *  Domain services are structured in such a way that if necessary the core functionality of a domain service could be switched from that of WebApi to some other medium.
 2.  Layer Separation
     * Defined Data and Business Layers, factories for object creation, Business/Data Models.
     * Heavy use of access modifiers at the class level to keep the work for a domain within the domain service.
 3.  Base Health Check
     * The foundational health check components are added which will return a "Healthy" response is a system is responsive.  This provides for furture expansion which will be discussed below.
 4.  Use of EntityTypeConfigurations
 5.  BackgroundService
     * This was added not necessarily to show that it should be included, but more as a demonstration as to what it is.  Most likely in a containerized environment this would be its own "thing".
 6.  Swagger
     * NSwag and Api Controller decoration to generate swaggerdoc.
 7.  Global Exception Handler
     * Implemented as middleware component.
 8.  Unit Tests

## Todo
 1. Create NuGet library of Health Checks.
 2. Create NuGet library for middleware components.
 3. Create NuGet library for unit tests helps with HttpClient helpers.
 4. Create a BFF/Orchestration demo.
 5. Generalize Demo for a single domain service and create a Nuget template.
 6. Move Todo's to GitHub Project
 
