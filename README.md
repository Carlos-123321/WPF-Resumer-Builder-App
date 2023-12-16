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
