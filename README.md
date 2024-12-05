![image](https://github.com/user-attachments/assets/63bf7e0d-21bb-4fda-bd84-1788e38a3c98)
![image](https://github.com/user-attachments/assets/40413515-f530-4ef3-9e3f-541453265a61)
![image](https://github.com/user-attachments/assets/c6cfdb43-401c-4630-97b8-723096474101)


IMPORTANT:

The project is going to give you an error because in the App.Config of WPFResumeBuilder I hard coded the path for the database. 

To fix this all you have to do is put your respective directories which lead to the
MySQLiteDB.db:

<connectionStrings>
	<add name="MyDB" connectionString="Data Source=C:\Users\carlo\Desktop\Please Work\WPFResumerBuilder\FunWithDBSQLite\FunWithDBSQLite\bin\Debug\MySQLiteDB.db"/>
</connectionStrings>



<connectionStrings>
	<add name="MyDB" connectionString="Data Source=C:Enter your corresponding
directories\WPFResumerBuilder\FunWithDBSQLite\FunWithDBSQLite\bin\Debug\MySQLiteDB.db"/>
</connectionStrings>
