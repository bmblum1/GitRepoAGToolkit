# GitRepoAGToolkit
--------------------------AGTOOLKIT README-----------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------
>>>>>>> Version 1.0
--------------------------Application Outline--------------------------
-----------------------------------------------------------------------

--The main application is a .Net Core Web App that features a scale length calculator. The calculator takes 2 inputs (number of frets and desired scale length) to 	calculate each fret position on a guitar or any other stringed instrument. This calculation is critical to ensure each fret is at the correct spot to get the 	desire note/pitch. 
----The web form has input validation that throws edits when the values are invalid (in red, with a text edit) and notifies the use when the values are valid for the calculation (in green, with text edit.)
----The calculate button is disabled by default until the form has correct values.
----Features a dynamic table that populates data when the calculation is performed. On the form reset, the table is cleared. When the calculate button is clicked again, it clears the table and recalculates.
----The Domain project houses all the calculation logic, and handles setting up the API to use with the test data.
----Features both a Unit Testing suite which tests the domain logic and an integration suite that uses the SQL API database to GET, POST and DELETE test data. 

--The second application is an API that houses a SQL Server database that stores test data for the above integration suite. 
----The API has GET, POST and DELETE methods for interacting with the test data.
----Everything is currently running on my personal PC local. 

--Current plan is to upload this page to my business website when I create it (sometime later this year)


--------------------------Technologies Used---------------------------
----------------------------------------------------------------------

--Software: Visual Studio Community, Visual Studio Code, SQL Manager Studio, IIS Express
--Languages Used: C#, HTML, CSS, JavaScript, SQL
--Misc: .Net Core 2.2, Razor Pages, SQL Server API
