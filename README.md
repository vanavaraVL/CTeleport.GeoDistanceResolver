# GeoDistanceResolver

This project will find out distance between geocoordinate two points on Latitude and Longitude

## Project layout

- [Backend](./src/Backend/CTeleport.GeoDistanceResolver.Web) - endpoint of solution
- net core 3.1
- swagger

- [Backend.Tests](./src/Backend/CTeleport.GeoDistanceResolver.Test) - test solution
- unit test for common library
- integration test

- [Core](./src/Core/CTeleport.GeoDistanceResolver.Core) - common core library 
- for connect, get airport information from gateway
- for resolve distance

