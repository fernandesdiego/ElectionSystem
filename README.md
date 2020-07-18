# ElectionSystem
Purpose:
This system was created to make the CIPA elections.
Features:
The project hosted here contains a web version to manage the elections and a windows desktop app to consume the data from the web and save user votes.
Web version:
The authorized user can add and manage elections, each election has 2 states: started and finished. 
Each election has its own candidates which must be registered by the author of the election.
The user can add data about the candidates such role, department, picture, etc.
There's a page for consulting the results and its possible to download reports about any previous registered election.
Desktop version:
The desktop version was designed to consume the data provided from the web pannel. The app will get the current logged user and verify if there's a started election and if the user has already voted this year, if so, the app wont start. Otherwise, the user will see an introduction page.
The candidates page contains all the candidates registered on the current year's election, when the user selects one, there's a confirmation scren. Also there's a blank and null (i dont know why, it's a request from the user)
