# TAL Premium Calculator
Test project for permium calculator using dotnet core and angular

## Tech Stack
- Dotnet core 6
- Angular 14
- MSsqllocaldb

## Description
- The application takes Name, Date of Birth, Sum Insured and Occupation using template driven angular form to calculate premium. 
- Age is auto calculated from the Date of Birth and is kept as a readonly field. Max 70 age restriction has been enforced to date picker as well as before making calculation api call.
- After all the fields are filled in and occupation selected, the premium is calculated and displayed to the user.

- No authentication mechanism has been implemented in backend as well as frontend but may be done as per need.
- Backend data has been stored and fetched from three tables viz Ratings, Occupations, Members.
- Migrations have been added to create the tables from entities/models, which is then seeded using DbInitializer class.

- Interfaces and Concrete classes have been used to create repositories, which are configured as scoped services in Program.cs to achieve loose coupling.
- A global error handler is implemented to catch unhandled exceptions, log them and send a custom response to the client.


- Calculation formula is as below:

    `Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12`

    `TPD Premium Monthly = (Sum Insured * Occupation Rating Factor * Age) /1234`



    | Occupation  | Rating |
    | ------------- | ------------- |
    | Cleaner  | Light Manual  |
    | Doctor  | Professional  |
    | Author  | White Collar  |
    | Farmer  | Heavy Manual  |
    | Mechanic  | Heavy Manual  |
    | Florist  | Light Manual  |


    | Rating  | Factor |
    | ------------- | ------------- |
    | Professional  | 1.0  |
    | White Collar  | 1.25  |
    | Light Manual  | 1.50 |
    | Heavy Manual  | 1.75  |

## How to run?
   - Run directly in visual studio or run the command from cmd and access http://localhost:5021
        `dotnet run --project API/TAL.API.csproj` 



