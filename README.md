# XbimDevTest
This is my solution to the XBim interview test.

## Running the application
Clone the application onto your local machine, open through VS, and run. A browser window will open to the data endpoint by default.
To view different exercises, use "<your IIS URL>/data" or "<your IIS URL>/rooms".
To use another model, place a different .ifc file into Models.

## What is currently missing
Use of a live web service - I'm pretty sure my Azure trial has long since expired.
More effective use of patterns/structure. So far only a service pattern is in use as well as its related dependency injection, and despite the presence of interfaces, they're not strictly necessary unless I plan to overcomplicate it.
