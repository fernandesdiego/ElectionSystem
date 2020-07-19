# ElectionSystem

##### Purpose
This system was created to make the internal CIPA elections.

##### Features
The project hosted here contains a web version to manage the elections and a windows desktop app to consume the data from the web and save user votes.

###### Web version
The authorized user can add and manage elections, each election has 2 states: started and finished. 

Each election has its own candidates which must be registered by the author of the election.

The user can add data about the candidates such as role, department, picture, etc.

There's a page for consulting the results and it's possible to download reports about any previous registered election.

###### Desktop version
The desktop version was designed to consume the data provided from the web pannel. * At the moment there's no API to consume the data *

The app will get the current logged user, verify if there's a started election and if the user has already voted this year, if so, the app wont start. Otherwise, the user will see an introduction page on full screen.

The candidates page contains all the candidates registered on the current year's election, when the user selects one, there's a confirmation scren. Also there's a blank and null (could be only null but the user asked for both 🤷‍)

#### Technologies
The web version was designed following the MVC pattern with ASP.NET Core 2.2.0 and EFCore 2.1;

The desktop app was designed following the MVVM pattern with .NET 4.7.2 and EF 6.0;

MySQL was the database, runing on a CentOS server. 

* API for consuming data to be developed (maybe) *
