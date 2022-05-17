# Shape Position Calculator

## About the Project
---
- Built on .NETCore 5
- Console Application written in C# 
- Installed Libraries
    - NUnit Testing Framework
    - Fluent Assertions

## Requirements
---
Write code in the language of your choice implementing certain algorithms that
analyze rectangles and features that exist among rectangles. Your implementation is required to cover
the following:

 - Intersection: You must be able to determine whether two rectangles have one or more
intersecting lines and produce a result identifying the points of intersection. 
 - Containment: You must be able to determine whether a rectangle is wholly contained within
another rectangle
 - Adjacency: Implement the ability to detect whether two rectangles are adjacent. Adjacency is
defined as the sharing of at least one side. Side sharing may be proper, sub-line or partial. A
sub-line share is a share where one side of rectangle A is a line that exists as a set of points
wholly contained on some other side of rectangle B, where partial is one where some line
segment on a side of rectangle A exists as a set of points on some side of Rectangle B. 

## Running & Debugging
---
- In Visual Studio
    - Ensure that the `ShapePosition` project is set as the start up project
    - Hit `F5` or click the `run` button denoted by a green triangle in the tool bar
    - To run the unit tests
        - Test > Run All Tests
        - Can be viewed in the `Test Explorer` 
        - Tests can also be ran or debugged individually by selecting the desired test in the test explorer > right click > run / debug

## Using the Console App
---
- User will be prompted to enter coordinates for two rectangles
    - `X` then `Y` coordinates for top left corner of first rectangle
    - `X` then `Y` coordinates for bottom right corner of first rectangle
    - Repeat steps above for second rectangle
- User will be notified of 
    - any non integer values
    - values that do not create a valid rectangle
        - ex. Attempting to set the bottom right corner to the left of the top left corner

Input
```
Rectangle1 Top Left X : 1, Top Left Y : 5, Bottom Right X: 4, Bottom Right Y: 3 
Rectangle2 Top Left X : 2, Top Left Y : 4, Bottom Right X: 3, Bottom Right Y: 1 
```

Response
```
Results:
Is Intersecting: True
    Points of Intersect: {X=2,Y=3}, {X=3,Y=3}
Is Adjacent: False
    Adjacency Type: None
Is Contained: False
```


## Design Choices
---
- I knew I wanted to separate out concerns by their respective algorithms for cleanliness and unit testing. 
- Each Calculator class to have it's own model which would be set as a property on the `PositionResponse` model. 
   - If this was an HTTP response, we would then be able to serialize `PositionResponse` as JSON
- Deciding to build this as a console app had its drawbacks. Primarily around input validation. I was able to use some recursion to minimize repetitiveness but being able to parse a query string or request body would've been more desireable. 

## Expansion Thoughts
---
- Building this out as an API 
    - exposing an endpoint that returns the `PositionResponse` 
    - exposing individual endpoints for each of the models contained within `PositionResponse` 
- I named the project `Recangles` originally. I think `ShapePosition` is more appropriate with the following in mind
   - Expand beyond rectangles and incorporate other shapes
    - **Loosely thought out**
        - Rectangle,Triangle etc. would implement an `IShape` interface
        - `RectanglePositionCalculator` would implement an `IPositionCalculator` interface
            - `RectanglePositionCalculator(IShape rectangle1, IShape rectangle2)`
            - `TrianglePositionCalculator(IShape triangle1, IShape triangle2)`
            - `IPositionCalculator.Calculate()`
        - Possibly a factory class that creates the appropriate implementation of the position calculator based on the input.

- Re `Adjacency`
    - Non-wholly contained rectangle sharing an adjacent side
    - Possibly an additional `AdjacencyType` when one adjacent rectangle's `X` coordinates exceed the others (like a letter "T")
    - Support adjacency checks for top and bottom
    - Support more than 1 adjacent side 












