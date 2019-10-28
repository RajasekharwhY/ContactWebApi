# ContactWebApi
Contact WebApi 


Used follwoing pacakges:
------------------------

Autofac - for Depenecy Injection
AutoMapper - for Entity to Model Mapping 
Newtonsoft.Json - for Json serialisation.


Completed End points :
----------------------
GET   - Api/Contacts
GET   - Api/Contacts/{id}
DELETE - - Api/Contacts/{id}

Not completed End points :
--------------------------
The code to handle various return status codes are completed for POST and PUT 
but due to Autofac mapping un resolved issues currenlty it is not testable. 

Database (LocalDB):
-------------------
Below project uses: Local db (Which comes with most versions of V.S)
The connection string mentioned in the web config file will automatically configures the localDB for testing.
<connectionStrings>
    <add connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True" name="DefaultConnection" providerName="System.Data.SqlClient" />
  </connectionStrings>
  
DatabaseInitializer.cs -> File has DatabaseInitializer class and Seed method handles adding the intial set of Data (Adding 2 contacts) 