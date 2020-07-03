# GeoDistanceResolver

This project will find out distance between geocoordinate two points on Latitude and Longitude

## Project layout

- [Backend](./src/Backend/CTeleport.GeoDistanceResolver.Web) - endpoint of solution
: net core 3.1
: swagger

- [Backend.Tests](./src/Backend/CTeleport.GeoDistanceResolver.Test) - test solution
: unit test for common library
: integration test

- [Core](./src/Core/CTeleport.GeoDistanceResolver.Core) - core library 
: for connect, get airport information from gateway
: for resolve distance


- [Core.Data](./src/Core/CTeleport.GeoDistanceResolver.Data) - common library 
: exceptions
: for dto, utils and etc

- [Core.Application](./src/Core/CTeleport.GeoDistanceResolver.Application) - application layer
: dto models, transform, resolve airports, find distances, methods of application
