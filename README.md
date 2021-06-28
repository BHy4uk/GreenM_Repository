# GreenM_Repository

#A set of startup instructions for GreenM_Test API project:

1. Prees green "Code" button and to download repository from GitHub to your own PC. (To open project you should have Visual Studio with .NET 5 version installed);
2. Open GreenM_Test.sln to run the project.

#A set of SQL Server instructions:
1. Create new Database in Microsoft SQL Server Managment Studio.
2. Use ScriptDB.sql to Import Data to your database.

#A set of instructions on how to test REST API Endpoints requests:

1. In opened project press "F5" or "Debug" button .
2. Swagger endpoint will be opened in your default browser.

#To get access to "User and device registration dynamics endpoint" 
  1.Press GET /api/UsersRegistrations/GetUsersRegistrationSpecified/{id}.
  2 Press "Try it out" button;
  3 Enter the number of the Month ( 1 is January, 12 is December);
  4 Press "Execute" button;
  5 API is secured by a key, so copy Request URL: http://localhost:45486/api/UsersRegistrations/GetUsersRegistrationSpecified/8;
  6 Open Postman app and paste copied link there;
  7 In headers menu enter key name and value. KEY: x-api-key . VALUE : GreenMSecretKey
  8 Press "SEND" button
  
#To get access to "List of users and devices with concurrent logins extended with the last occurence of the login from unexpected 
country" 
  1 Choose GET /api/Logged/{id} in Swagger endpoint.
  2 Press "Try it out" button;
  3 Enter logged_id ;
  4 Press "Execute" button;
  5 API is secured by a key, so copy Request URL: http://localhost:45486/api/Logged/3;
  6 Open Postman app and paste copied link there;
  7 In headers menu enter key name and value. KEY: x-api-key . VALUE : GreenMSecretKey
  8 Press "SEND" button
  
  #Docker HUB
  
  Use a link to get docker imaage with the API: 
  https://hub.docker.com/r/necheporenkoillia/greenm_test
