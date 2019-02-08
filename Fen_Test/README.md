# ASP.NET ZERO

This repository is configured and used for AspNet Zero Team's development. 
It is not suggested for our customers to use this repository directly. It is suggested to download a project from https://aspnetzero.com/Download.



<---------------------------- Instructions to use the code of this Fen_Test Project ---------------------------->

1.) Open the .sln file from the downloded code.
2.) Set the Fen_Test.Web.Mvc project as the StartUp Project.
3.) Open applicationsettings.json file and Enter your connection string according to your SQL Server i.e. change the Server, User ID, Password and Database name.
4.) Now open the Package Manager Console from the Tools menu.
5.) Select the Fen_Test.EntityFramework as the Default project in it.
6.) Then write the command 'update-database' in Package Manager Console and execute it.
7.) After executing the command a new database for you project will be created on your SQL Server.
8.) Right click on the gulp.js file and select Task Runner Explorer a new window will open. On the left hand side select the task and choose binding before build and build the project. This will remove the jquery errors which occurs on the console.
9.) And now your project is ready to run.

Note : We are using Visual Studio 2017. And it is recoomended to use the same version of Visual Studio, so that the vesion will not create any problem in future.

<-------------The code in this project includes following content--------------->
1.) Inside Areas/App/Controller one can find field controller in which methods to display the created field and create or edit fields part is done
2.) I have used Kendo window inside partial View So as to reuse that window as an when required.Its related Js file can be found in wwwroot/view-resources folder.
3.) Also I had applied server side pagination to load data inside the field grid.
4.) To run Fields Controller hit- App/Field/Index
5.) Created Custom User repository(inside Fen_Test.EntityFramework/Authorization) to fetch the data from database using stored procedure as per the requirement.
6.) Create MyCustom controller there you can find Reportpage Action method where I have implemented the logic for report creation and query builder page.
7.) Also I have tried to create the Side bar menues in the MyCustomController Index page using teh View Components. You can find the View Components in the Areas/Views/MyCustom/Components folder.
8.) In order to run the MyCustom/index page where the view component logic is written you need to uncomment the few lines in teh pageViewComponent and the NavBarItems View model.
9.) To run using the View component hit - App/Mycustom/index
10.) The Same report page I have implemented without using view component this you can find it in App/MyCustom/ReportPgae





