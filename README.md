# HotellApp

## Installation guide
*Prerequisits:*
* This project uses angular v23.1.0
* This project uses SQL Server

If you do not have an SQL server locally running, you can grab the "developer edition" from: "https://www.microsoft.com/en-us/sql-server/sql-server-downloads" (no sign up required).
"Basic" installation will suffice.

# Update Database
To update database in visual studio HotellApp.Server needs to be selected as the startup project and default project needs to be HotellApp.Data. I did not include seeds, so all Data needed for testing needs to be entered manually via UI.

# Project details
To run the project properly, run both HotellApp.Server and HotellApp.Client via "Multiple startup projects:" option in visual studio.

There are 2 sections to the UI. "Register" and "Manage". 

## Manage section
User can add new rooms, delete existing rooms and query for bookings within a given timeframe.
User can delete bookings that are more than 72 hours before the booking start date.

## Register section
User can look for vacant rooms via selecting booking start and end dates. The "submit" button will query for vacant rooms within that timeframe.
Default query value is vacant rooms 3 days from now for 1 day.
User can register a person to a vacant rooms based on the VacantRoom query (StartDate and EndDate prefilled in the "Register for Room" form).

## X-Road Middleware
implemented but not fully utilized due to just being a test project. 
